using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1
{
     public enum LessonType
        {
            VideoLesson,
            TextLesson
        }
    public class Lesson : BaseEntity, IVersionable, ICloneable
    {

        byte[] lessonVersion = new byte[8];
        public List<Material> Materials { get; set; } = new List<Material>();
        public override Guid Id { get => Id; set => this.GenerateId(); }

        public Lesson(List<Material> Materials)
        {
            Description = "This is a lesson";
        }

        public void SetVersion(byte[] version) 
        {
            lessonVersion = version;
        }

        public byte[] GetVersion()
        {
            return lessonVersion;
        }

        public LessonType GetTrainingType()
        {
            foreach (var material in Materials)
            {
                if (material is VideoMaterial)
                    return LessonType.VideoLesson;
            }
            return LessonType.TextLesson;
        }

        public object Clone()
        {
            Lesson cloneClass = new Lesson( Materials);
            cloneClass.lessonVersion = new byte[8];
            Array.Copy(this.lessonVersion, cloneClass.lessonVersion, this.lessonVersion.Length);
            cloneClass.Id = this.Id;
            return cloneClass;
        }
    }
}
