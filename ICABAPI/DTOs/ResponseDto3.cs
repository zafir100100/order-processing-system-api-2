using System.Runtime.Serialization;

namespace ICABAPI.DTOs
{
    public class ResponseDto3
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        [IgnoreDataMember]
        public int StatusCode { get; set; }
        public object Payload { get; set; }
    }
}