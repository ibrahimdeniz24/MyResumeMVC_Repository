namespace MyResume.UI.Extantions
{
    public static class FormExtantions
    {

        public static async Task<byte[]> StringToByteArrayAsync(this IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                throw new ArgumentException("Dosya yüklenmedi veya boş.", nameof(formFile));
            }

            using MemoryStream memory = new MemoryStream();
            await formFile.CopyToAsync(memory);
            return memory.ToArray();
        }




    }
}
