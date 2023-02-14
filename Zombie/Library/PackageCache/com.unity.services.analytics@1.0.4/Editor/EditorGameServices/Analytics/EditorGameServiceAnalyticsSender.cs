using System;
using Unity.Services.Core.Editor;
using UnityEditor;
using UnityEngine;

namespace Unity.Services.Analytics.Editor
{
    static class EditorGameServiceAnalyticsSender
    {
        static class AnalyticsComponent
        {
            public const string ProjectSettings = "Project Settings";
            public const string TopMenu = "Top Menu";
        }

        static class AnalyticsAction
        {
            public const string Configure = "Configure";
            public const string LearnMore = "Learn More";
            public const string ContactSupport = "Contact Support";
        }
        
        const int k_Version = 1;
        const string k_EventName = "editorgameserviceeditor";

        static IEditorGameServiceIdentifier s_Identifier;

        static IEditorGameServiceIdentifier Identifier
        {
            get
            {
                if (s_Identifier == null)
                {
                    s_Identifier = EditorGameServiceRegistry.Instance.GetEditorGameService<AnalyticsIdentifier>().Identifier;
                }

                return s_Identifier;
            }
        }
        
        internal static void SendProjectSettingsLearnMoreEvent()
        {
            SendEvent(AnalyticsComponent.ProjectSettings, AnalyticsAction.LearnMore);
        }
        
        internal static void SendProjectSettingsContactSupportEvent()
        {
            SendEvent(AnalyticsComponent.ProjectSettings, AnalyticsAction.ContactSupport);
        }

        internal static void SendTopMenuConfigureEvent()
        {
            SendEvent(AnalyticsComponent.TopMenu, AnalyticsAction.Configure);
        }

        static void SendEvent(string component, string action)
        {
            EditorAnalytics.SendEventWithLimit(k_EventName, new EditorGameServiceEvent
            {
                action = action,
                component = component,
                package = Identifier.GetKey()
            }, k_Version);
        }

        /// <remarks>Lowercase is used here for compatibility with analytics.</remarks>
        [Serializable]
        public struct EditorGameServiceEvent
        {
            public string action;
            public string component;
            public string package;
        }
    }
}
