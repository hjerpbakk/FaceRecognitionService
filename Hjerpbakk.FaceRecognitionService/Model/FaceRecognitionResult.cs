using System;

namespace Hjerpbakk.FaceRecognitionService.Model
{
    /// <summary>
    ///     Result of a facial recognition.
    /// </summary>
    public struct FaceRecognitionResult : IEquatable<FaceRecognitionResult>
    {
        /// <summary>
        ///     Creates a failed result with the given errors.
        /// </summary>
        /// <param name="errors">The things that were wrong with the image.</param>
        public FaceRecognitionResult(string errors) : this(false, errors)
        {
            if (string.IsNullOrEmpty(errors))
            {
                throw new ArgumentException(nameof(errors));
            }
        }

        FaceRecognitionResult(bool isValid, string errors)
        {
            IsValid = isValid;
            Errors = errors;
        }

        /// <summary>
        ///     Whether the image was valid.
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        ///     The things that were wrong with the image.
        /// </summary>
        public string Errors { get; }

        /// <summary>
        ///     Creates a valid result.
        /// </summary>
        public static FaceRecognitionResult Valid => new FaceRecognitionResult(true, "");

        public bool Equals(FaceRecognitionResult other)
        {
            return IsValid == other.IsValid && string.Equals(Errors, other.Errors);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is FaceRecognitionResult && Equals((FaceRecognitionResult)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (IsValid.GetHashCode() * 397) ^ (Errors != null ? Errors.GetHashCode() : 0);
            }
        }
    }
}
