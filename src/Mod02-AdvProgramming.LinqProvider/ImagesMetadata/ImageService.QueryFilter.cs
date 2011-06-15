using System;
using System.Text;

namespace Mod02_AdvProgramming.LinqProvider.ImagesMetadata
{
    public partial class ImageService
    {
        public class QueryFilter
        {
            public string MinDateTaken;
            public string MaxDateTaken;
            public int MinDaysTaken;
            public int MaxDaysTaken;

            public string CameraModel;
            public string CameraManufacturer;


            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ImagesIndex.QueryFilters Dump");
                DumpEqualCondition(sb, "CameraModel", this.CameraModel);
                DumpBetweenCondition(sb, "DateTaken", this.MinDateTaken.ToString(), this.MaxDateTaken);
                return sb.ToString();
            }

            internal void DumpEqualCondition(StringBuilder sb, string fieldName, string value)
            {
                if (value != null)
                {
                    sb.Append(fieldName);
                    sb.Append(" = ");
                    sb.AppendLine(value.ToString());
                }
            }
            internal void DumpBetweenCondition<T>(StringBuilder sb, string fieldName, T limitMin, T limitMax)
                where T : IComparable<T>
            {
                if (!limitMin.Equals(default(T)) && !limitMax.Equals(default(T)))
                {
                    sb.Append(fieldName);
                    sb.Append(" BETWEEN ");
                    sb.Append(limitMin.ToString());
                    sb.Append(" AND ");
                    sb.AppendLine(limitMax.ToString());
                }
                else if (limitMin.Equals(default(T)))
                {
                    sb.Append(fieldName);
                    sb.Append(" >= ");
                    sb.AppendLine(limitMin.ToString());
                }
                else if (limitMax.Equals(default(T)))
                {
                    sb.Append(fieldName);
                    sb.Append(" <= ");
                    sb.AppendLine(limitMax.ToString());
                }
            }
        }
    }
}