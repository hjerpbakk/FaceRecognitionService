using System;

namespace Hjerpbakk.FaceRecognitionService.Configuration
{
    public interface IFaceRecognitionConfiguration
    {
        /// <summary>
        ///     The access key for the Azure Cognitive Services.
        /// </summary>
        string Key { get; }

        /// <summary>
        ///     The URL to the Azure Cognitive Services API.
        /// </summary>
        string URL { get; }

        /// <summary>
        ///     The time to wait if calls to the Azure Cognitive Services
        ///     are throttled.
        /// </summary>
        TimeSpan Delay { get; }
    }
}
