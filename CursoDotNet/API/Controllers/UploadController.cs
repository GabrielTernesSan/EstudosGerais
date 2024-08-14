using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using ImageProcessorCore.Plugins.WebP.Formats;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(IFormFile image)
        {
            try
            {
                if (image == null)
                    return null;

                using (var stream = new FileStream(Path.Combine("Imagens", image.FileName), FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                var webpNameImage = Guid.NewGuid() + ".webp";

                using (var webpFileStream = new FileStream(Path.Combine("Imagens", webpNameImage), FileMode.Create))
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                    {
                        imageFactory.Load(image.OpenReadStream())
                            .Format(new WebPFormat())
                            .Quality(100)
                            .Save(webpFileStream);
                    }
                }

                return Ok(new
                {
                    mensagem = "Imagem salva com sucesso!",
                    urlImage = $"http://localhost:5000/img/{image.FileName}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro no upload" + ex.Message);
            }
        }
    }
}
