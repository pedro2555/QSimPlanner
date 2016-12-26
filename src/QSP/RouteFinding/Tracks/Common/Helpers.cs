﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using QSP.LibraryExtension;
using QSP.RouteFinding.Airports;
using QSP.RouteFinding.Tracks.Ausots;
using QSP.RouteFinding.Tracks.Interaction;
using QSP.RouteFinding.Tracks.Nats;
using QSP.RouteFinding.Tracks.Pacots;

namespace QSP.RouteFinding.Tracks.Common
{
    public static class Helpers
    {
        public static readonly IReadOnlyList<string> TrackStrings;
        public static readonly IReadOnlyList<TrackType> TrackTypes;
        public static readonly IReadOnlyDictionary<string, TrackType> TrackTypeLookup;
        public static readonly IReadOnlyDictionary<Type, TrackType> TypeToTrackType;

        static Helpers()
        {
            TrackStrings = new[] { "NATs", "PACOTs", "AUSOTS" };
            TrackTypes = Enums.GetValues<TrackType>().ToList();
            TrackTypeLookup = TrackTypes.ToDictionary(t => TrackString(t), t => t);
            TypeToTrackType = new Dictionary<Type, TrackType>()
            {
                [typeof(NorthAtlanticTrack)] = TrackType.Nats,
                [typeof(PacificTrack)] = TrackType.Pacots,
                [typeof(AusTrack)] = TrackType.Ausots
            };
        }

        public static TrackType ToTrackType(this string trackType) => TrackTypeLookup[trackType];

        public static string TrackString(this TrackType item) => TrackStrings[(int)item];

        public static ITrackMessageProvider GetTrackDownloader<T>() where T : Track
        {
            return GetTrackDownloader(GetTrackType<T>());
        }

        public static ITrackMessageProvider GetTrackDownloader(TrackType t)
        {
            return new ITrackMessageProvider[]
            {
                new NatsDownloader(),
                new PacotsDownloader(),
                new AusotsDownloader(),
            }[(int)t];
        }

        public static ITrackParser<T> GetParser<T>(ITrackMessageNew msg,
            StatusRecorder statusRecorder, AirportManager airportList) where T : Track
        {
            return (ITrackParser<T>)new object[]
            {
                new NatsParser(msg, statusRecorder, airportList),
                new PacotsParser(msg, statusRecorder, airportList),
                new AusotsParser(msg, statusRecorder, airportList),
            }[(int)GetTrackType<T>()];
        }

        public static TrackType GetTrackType<T>() where T : Track
        {
            return TypeToTrackType[typeof(T)];
        }

        public static ITrackMessageNew GetTrackMessage(TrackType t, XDocument doc)
        {
            if (t == TrackType.Nats) return new NatsMessage(doc);
            if (t == TrackType.Pacots) return new PacotsMessage(doc);
            if (t == TrackType.Ausots) return new AusotsMessage(doc);
            throw new ArgumentException();
        }
    }
}