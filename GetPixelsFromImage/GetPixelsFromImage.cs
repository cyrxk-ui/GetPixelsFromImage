using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Activities;

namespace GetPixelsFromImage.Activities
{
    [DisplayName("Get Pixels From Image")]
    public sealed class GetPixelsFromImage : NativeActivity
    {

        [Category("Input")]
        public InArgument<Image> Image { get; set; }

        [Category("Input")]
        public InArgument<String> FilePath { get; set; }

        [Category("Output")]
        public OutArgument<Color[]> Pixels { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Image img;
            if (context.GetValue(this.Image) is null)
            {
                img = System.Drawing.Image.FromFile(context.GetValue(this.FilePath));
            }
            else
            {
                img = context.GetValue(this.Image);
            }
            Bitmap bmp = new Bitmap(img);
            Color[] pixels = new Color[img.Width * img.Height];
            for (int i=0; i < img.Height; i++) {
                for (int j=0; j<img.Width; j++)
                {
                    pixels[img.Width * i + j] = bmp.GetPixel(j, i);
                }
            }

            Pixels.Set(context, pixels);
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            if ((Image is null) && (FilePath is null))
            {
                metadata.AddValidationError("Image or FilePath is required.");
            }
            if (!(Image is null) && !(FilePath is null))
            {
                metadata.AddValidationError("Cannot accept both Image and FilePath.");
            }
            base.CacheMetadata(metadata);
        }
    }
}
