namespace CalibrationTracking.Abstractions.Exceptions
{
    [Serializable]
    public class ValidatioFailedException : Exception
    {
        public ValidatioFailedException(List<string> errors)
        {
            Errors = errors;
        }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
