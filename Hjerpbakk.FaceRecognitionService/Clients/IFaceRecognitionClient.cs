using System;
using System.Threading.Tasks;
using Hjerpbakk.FaceRecognitionService.Model;

namespace Hjerpbakk.FaceRecognitionService.Clients
{
    /// <summary>
    ///     Client for recognizing faces i Slack profile images.
    /// </summary>
    public interface IFaceRecognitionClient
    {
        /// <summary>
        ///     Validates a Slack user's profile image.
        ///     The image is valid if it's recognized as an
        ///     image of a single human.
        /// </summary>
        /// <param name="imageURL">URL to the image we should find faces in.</param>
        /// <returns>The result of the face detection.</returns>
        Task<FaceRecognitionResult> ValidateProfileImage(Uri imageURL);
    }
}
