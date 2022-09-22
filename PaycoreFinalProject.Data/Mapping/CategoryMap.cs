using PaycoreFinalProject.Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PaycoreFinalProject.Data.Mapping
{
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Id(x => x.CategoryId, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("categoryid");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });
            Property(x => x.CategoryName, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.Column("categoryname");
                x.NotNullable(true);
            });
            Property(x => x.Description, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.Column("description");
            });
            Table("category");
        }

    }
}
