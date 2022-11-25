namespace MVC.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}