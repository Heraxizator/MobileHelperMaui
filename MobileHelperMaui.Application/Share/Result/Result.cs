namespace MobileHelperMaui.Application.Share.Result
{
    public class Result
    {
        private Result(bool isSuccess, Error error)
        {
            if ((isSuccess && error != Error.None) ||
                (!isSuccess && error == Error.None))
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            this.IsSuccess = isSuccess;
            this.Error = error;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !this.IsSuccess;

        public Error Error { get; }

        public static Result Success()
        {
            return new(true, Error.None);
        }

        public static Result Failure(Error error)
        {
            return new(false, error);
        }
    }
}
