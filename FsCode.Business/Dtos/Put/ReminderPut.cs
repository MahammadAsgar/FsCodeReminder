namespace FsCodeBusiness.Dtos.Put
{
    public class ReminderPut
    {
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime? SendAt { get; set; }
        public string Method { get; set; }
    }
}
