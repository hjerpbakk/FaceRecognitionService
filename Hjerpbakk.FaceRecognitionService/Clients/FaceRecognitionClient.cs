using System;
using System.Threading.Tasks;
using Hjerpbakk.FaceRecognitionService.Configuration;
using Hjerpbakk.FaceRecognitionService.Model;
using Microsoft.ProjectOxford.Face;

namespace Hjerpbakk.FaceRecognitionService.Clients
{
    /// <summary>
    ///     Client for recognizing faces i Slack profile images.
    /// </summary>
    public class FaceRecognitionClient : IFaceRecognitionClient
    {
        readonly int delay;

        readonly IFaceServiceClient faceServiceClient;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="faceServiceClient">Client for calling Azure Cognitive Services.</param>
        /// <param name="configuration">The configuration to use.</param>
        public FaceRecognitionClient(IFaceServiceClient faceServiceClient, IFaceRecognitionConfiguration configuration)
        {
            this.faceServiceClient = faceServiceClient ?? throw new ArgumentNullException(nameof(faceServiceClient));
            delay = configuration.Delay.Milliseconds;
        }

        /// <summary>
        ///     Validates a Slack user's profile image.
        ///     The image is valid if it's recognized as an
        ///     image of a single human.
        /// </summary>
        /// <param name="imageURL">URL to the image we should find faces in.</param>
        /// <returns>The result of the face detection.</returns>
        public async Task<FaceRecognitionResult> ValidateProfileImage(Uri imageURL)
        {
            if (imageURL == null)
            {
                throw new ArgumentNullException(nameof(imageURL));
            }

            try
            {
                const int Tries = 6;
                for (var i = 0; i < Tries; ++i)
                {
                    try
                    {
                        var faces = await faceServiceClient.DetectAsync(imageURL.AbsoluteUri, false);
                        switch (faces.Length)
                        {
                            case 0:
                                return new FaceRecognitionResult("Kunne ikke se et ansikt i bildet ditt. Last opp et profilbilde av deg selv.");
                            case 1:
                                return FaceRecognitionResult.Valid;
                            default:
                                return new FaceRecognitionResult("Fant flere ansikter i bildet litt. Last opp et profilbilde av deg selv.");
                        }
                    }
                    catch (FaceAPIException)
                    {
                        await Task.Delay(delay * i);
                    }
                }

                return FaceRecognitionResult.Valid;
            }
            catch (Exception)
            {
                // TODO: Log exception here
                return FaceRecognitionResult.Valid;
            }
        }
    }
}
