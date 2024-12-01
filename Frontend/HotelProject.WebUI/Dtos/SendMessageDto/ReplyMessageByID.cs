using System;

namespace HotelProject.WebUI.Dtos.SendMessageDto
{
    public class ReplyMessageByID
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }

        public string Message { get; set; }
        public CreateSendMessageDto SendMessage { get; set; }
    }
}
