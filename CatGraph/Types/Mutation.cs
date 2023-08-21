namespace CatGraph.Types
{
    public class Mutation
    {
        public async Task<string> UploadAsync(IFile file, CancellationToken cancellation)
        {
            // Define the supported file extensions
            string[] supportedExtensions = { "AAC", "AMR", "AVI", "JFIF", "JPE", "JPEG", "JPG", "M4A", "M4V", "MOV", "MP3", "MP4", "MPEG", "MPG", "PDF", "PNG", "WAV", "XML" };

            // Check if the file extension is supported
            string fileExtension = System.IO.Path.GetExtension(file.Name).Trim('.').ToUpper();
            if (!supportedExtensions.Contains(fileExtension))
            {
                return "Unsupported file extension";
            }

            // Check if the file size is within the allowed range (1KB to 100MB)/ Just for this example. We will config size limit in program.cs. This code will be not appear in Sofia
            long fileSizeInBytes = (long)file.Length;
            if (fileSizeInBytes < 1024 || fileSizeInBytes > 100 * 1024 * 1024)
            {
                return "File size out of range";
            }

            // Define magic bytes for supported file types (replace with actual values)
            Dictionary<string, byte[]> magicBytesForTypes = new Dictionary<string, byte[]>
            {
                {"AAC", new byte[] {0xFF, 0xF1}},                 // Magic bytes for AAC
                {"AMR", new byte[] {0x23, 0x21, 0x41, 0x4D, 0x52}}, // Magic bytes for AMR
                {"AVI", new byte[] {0x52, 0x49, 0x46, 0x46}},     // Magic bytes for AVI
                {"JFIF", new byte[] {0xFF, 0xD8, 0xFF, 0xE0}},   // Magic bytes for JFIF (JPEG)
                {"JPE", new byte[] {0xFF, 0xD8, 0xFF, 0xE0}},    // Magic bytes for JPE (JPEG)
                {"JPEG", new byte[] {0xFF, 0xD8, 0xFF, 0xE0}},   // Magic bytes for JPEG
                {"JPG", new byte[] {0xFF, 0xD8, 0xFF, 0xE0}},    // Magic bytes for JPG
                {"M4A", new byte[] {0x4D, 0x34, 0x41, 0x20}},     // Magic bytes for M4A
                {"M4V", new byte[] {0x4D, 0x4F, 0x56, 0x49}},     // Magic bytes for M4V
                {"MOV", new byte[] {0x66, 0x74, 0x79, 0x70}},     // Magic bytes for MOV
                {"MP3", new byte[] {0xFF, 0xFB}},                 // Magic bytes for MP3
                {"MP4", new byte[] {0x66, 0x74, 0x79, 0x70}},     // Magic bytes for MP4
                {"MPEG", new byte[] {0x00, 0x00, 0x01, 0xBA}},   // Magic bytes for MPEG
                {"MPG", new byte[] {0x00, 0x00, 0x01, 0xBA}},    // Magic bytes for MPG
                {"PDF", new byte[] {0x25, 0x50, 0x44, 0x46}},     // Magic bytes for PDF
                {"PNG", new byte[] {0x89, 0x50, 0x4E, 0x47}},     // Magic bytes for PNG
                {"WAV", new byte[] {0x52, 0x49, 0x46, 0x46}},     // Magic bytes for WAV
                {"XML", new byte[] {0x3C, 0x3F, 0x78, 0x6D, 0x6C}} // Magic bytes for XML
            };

            // Check magic bytes (if available for the file type)
            if (magicBytesForTypes.ContainsKey(fileExtension))
            {
                byte[] magicBytes = magicBytesForTypes[fileExtension];
                byte[] fileMagicBytes = new byte[magicBytes.Length];

                // Read the magic bytes from the file
                using (var stream = file.OpenReadStream())
                {
                    await stream.ReadAsync(fileMagicBytes, 0, magicBytes.Length);
                }

                if (!fileMagicBytes.SequenceEqual(magicBytes))
                {
                    return "Magic bytes do not match";
                }
            }

            return file.Name;
        }
    }
}
