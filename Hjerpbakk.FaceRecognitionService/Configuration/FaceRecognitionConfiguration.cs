using System;
using Newtonsoft.Json;

namespace Hjerpbakk.FaceRecognitionService.Configuration
{
    /// <summary>
    ///     Configuration needed to use the Azure Cognitive Services.
    /// </summary>
    public struct FaceRecognitionConfiguration : IFaceRecognitionConfiguration
    {
        /// <summary>
        ///     The access key for the Azure Cognitive Services.
        /// </summary>
        [JsonProperty("faceAPIAccessKey")]
        public string Key { get; set; }

        /// <summary>
        ///     The URL to the Azure Cognitive Services API.
        /// </summary>
        [JsonProperty("faceAPIURL")]
        public string URL { get; set; }

        /// <summary>
        ///     The time to wait if calls to the Azure Cognitive Services
        ///     are throttled.
        /// </summary>
        public TimeSpan Delay { get; set; }
    }
}
