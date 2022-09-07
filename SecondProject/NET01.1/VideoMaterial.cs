using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1
{
    public enum Videoformat
    {
        Unknown,
        Avi,
        Mp4,
        Flv
    }
    public class VideoMaterial : Material, IVersionable
    {
        private string _videoURI;
        public string videoURI 
        { 
            get { return _videoURI; }          
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Video URI cannot be empty.");
                }
                _videoURI = value;
            }
        }
        public string splashURI { get; set; }
        public Videoformat videoFormat { get; set; }

        public override Guid Id { get => Id; set => this.GenerateId(); }

        byte[] videoVersion = new byte[8];

        public void SetVersion(byte[] version) 
        {
            videoVersion = version;
        }

        public byte[] GetVersion()
        {
            return videoVersion;
        }

        public VideoMaterial(string videoU, string splashU, Videoformat format)
        {
            
            videoURI = videoU;
            splashURI = splashU;
            videoFormat = format;
            Description = "This is a section for video materials";
        }

       
        public override string ToString()
        {
            return "Here you will find video materials for the lesson.";
        }

        public object Clone()
        {
            VideoMaterial cloneClass = new VideoMaterial("youtube.com", "image.com", Videoformat.Mp4);
            cloneClass.videoVersion = new byte[8];
            Array.Copy(this.videoVersion, cloneClass.videoVersion, this.videoVersion.Length);
            cloneClass.Id = this.Id;
            cloneClass.videoURI = this.videoURI;
            cloneClass.videoFormat = this.videoFormat;
            cloneClass.splashURI = this.splashURI;
            return cloneClass;
        }
        /*
        public override void Validation()
        {
            if (string.IsNullOrEmpty(videoURI))
            {
                throw new ArgumentException("Video URI cannot be empty.");
            }
        }
        */


    }
}
