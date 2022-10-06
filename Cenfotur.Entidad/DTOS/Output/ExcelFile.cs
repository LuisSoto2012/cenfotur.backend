using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class ExcelFile
    {
        public Byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}