﻿using RiotSharp.Endpoints.MatchEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.Endpoints.MatchEndpoint.Enums;

namespace RiotSharpExtensions.EndpointServices.Matches
{
    public class PlayerSpecificTimelineServices
    {
        /// <summary>
        /// Get the champion kills performed between two timepoints by <paramref name="participantId"/>
        /// </summary>
        /// <param name="timeline">Timeline to filter events from</param>
        /// <param name="start">Start timepoint</param>
        /// <param name="end">End timepoint</param>
        /// <param name="participantId"></param>
        /// <returns></returns>
        public static int GetKillsFromTo(MatchTimeline timeline, TimeSpan start, TimeSpan end, int participantId)
        {
            return timeline.GetEventsFromTo(start, end)
                .Count(ev => ev.EventType == MatchEventType.ChampionKill &&
                ev.KillerId == participantId);
        }

        /// <summary>
        /// Get the champion assists performed between two timepoints by <paramref name="participantId"/>
        /// </summary>
        /// <param name="timeline">Timeline to filter events from</param>
        /// <param name="start">Start timepoint</param>
        /// <param name="end">End timepoint</param>
        /// <param name="participantId"></param>
        /// <returns></returns>
        public static int GetAssistsFromTo(MatchTimeline timeline, TimeSpan start, TimeSpan end, int participantId)
        {
            return timeline.GetEventsFromTo(start, end)
                .Count(ev => ev.EventType == MatchEventType.ChampionKill &&
                ev.AssistingParticipantIds.Contains(participantId));
        }

        /// <summary>
        /// Get the deaths performed between two timepoints by <paramref name="participantId"/>
        /// </summary>
        /// <param name="timeline">Timeline to filter events from</param>
        /// <param name="start">Start timepoint</param>
        /// <param name="end">End timepoint</param>
        /// <param name="participantId"></param>
        /// <returns></returns>
        public static int GetDeathsFromTo(MatchTimeline timeline, TimeSpan start, TimeSpan end, int participantId)
        {
            return timeline.GetEventsFromTo(start, end)
                .Count(ev => ev.EventType == MatchEventType.ChampionKill &&
                ev.VictimId == participantId);
        }
    }
}
