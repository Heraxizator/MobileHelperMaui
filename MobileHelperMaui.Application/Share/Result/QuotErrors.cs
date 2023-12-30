namespace MobileHelperMaui.Application.Share.Result
{
    public static class QuotErrors
    {
        public static readonly Error CanNotLoad = new(
            "Quots.CanNotLoad", "Can not load the quot from API");

        public static readonly Error BadQuot = new(
            "Quots.BadQuot", "The quot does not satisfies one or more requirements");
    }
}
