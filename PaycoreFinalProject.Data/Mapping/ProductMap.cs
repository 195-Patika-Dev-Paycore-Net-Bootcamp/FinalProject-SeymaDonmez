using PaycoreFinalProject.Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PaycoreFinalProject.Data.Mapping
{
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.ProductId, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("productid");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });
            Property(x => x.ProductName, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.Column("productname");
                x.NotNullable(true);
            });
            Property(x => x.Description, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.Column("description");
                x.NotNullable(true);
            });
            Property(x => x.IsOfferable, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.Column("isofferable");
            });
            Property(x => x.IsSold, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.Column("issold");
            });
            Property(x => x.Status, x =>
            {
                x.Type(NHibernateUtil.Byte);
                x.Column("status");
            });
            Property(x => x.CategoryId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.Column("categoryid");
                x.NotNullable(true);
            });
            Property(x => x.Color, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.Column("color");
                x.NotNullable(true);
            });
            Property(x => x.Brand, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.Column("brand");
                x.NotNullable(true);
            });
            Property(x => x.Price, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.Column("price");
                x.NotNullable(true);
            });
            Bag(product => product.Offers, map => map.Key(k => k.Column("productid")), rel => rel.OneToMany());
            ManyToOne(product => product.User, map => map.Column("userid"));

            Table("product");
        }
    }
}
