﻿using QSP.RouteFinding.Tracks.Common;
using QSP.RouteFinding.Tracks.Interaction;
using QSP.RouteFinding.Tracks.Nats.Utilities;
using System;
using System.Collections.Generic;
using QSP.RouteFinding.Routes;

namespace QSP.RouteFinding.Tracks.Nats
{
    public class NatsParser : ITrackParser<NorthAtlanticTrack>
    {
        private static readonly char[] DelimiterWords = { ' ', '\n', '\r', '\t' };

        private StatusRecorder statusRecorder;
        private NatsMessage message;

        public NatsParser(ITrackMessage message, StatusRecorder statusRecorder)
        {
            this.message = (NatsMessage)message;
            this.statusRecorder = statusRecorder;
        }

        public List<NorthAtlanticTrack> Parse()
        {
            var NatTrackCollection = TryAddMessage(message.WestMessage);
            NatTrackCollection.AddRange(TryAddMessage(message.EastMessage));
            return NatTrackCollection;
        }

        private List<NorthAtlanticTrack> TryAddMessage(IndividualNatsMessage msg)
        {
            try
            {
                return ConvertToTracks(msg);
            }
            catch
            {
                var dir = msg.Direction == NatsDirection.East ? "eastbound" : "westbound";

                statusRecorder.AddEntry(
                    StatusRecorder.Severity.Caution,
                    $"Unable to interpret {dir} tracks.",
                    TrackType.Nats);

                return new List<NorthAtlanticTrack>();
            }
        }

        private static List<NorthAtlanticTrack> ConvertToTracks(IndividualNatsMessage msg)
        {
            char trkStartChar = msg.Direction == NatsDirection.West ? 'A' : 'N';

            var Message = msg.Message;
            var tracks = new List<NorthAtlanticTrack>();

            for (int i = trkStartChar; i < trkStartChar + 13; i++)
            {
                char id = (char)i;
                int j = Message.IndexOf($"\n{id} ");

                if (j < 0) continue;

                j += 2;
                var newLinePos = Message.IndexOf('\n', j);

                var route = Message.Substring(j, newLinePos - j)
                    .Split(DelimiterWords, StringSplitOptions.RemoveEmptyEntries);

                TryConvertNatsLatLon(route);

                tracks.Add(new NorthAtlanticTrack(
                    msg.Direction,
                    id.ToString(),
                    "",
                    "",
                    "",
                    route.ToRouteString()));
            }

            return tracks;
        }

        private static void TryConvertNatsLatLon(string[] wpts)
        {
            for (int i = 0; i < wpts.Length; i++)
            {
                var latLon = LatLonConverter.TryConvertNatsCoordinate(wpts[i]);
                if (latLon != null) wpts[i] = latLon.AutoChooseFormat();
            }
        }
    }
}
