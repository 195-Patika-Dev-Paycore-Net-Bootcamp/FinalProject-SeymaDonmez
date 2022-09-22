using PaycoreFinalProject.Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PaycoreFinalProject.Data.Mapping
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(x => x.UserId, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("userid");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(x => x.FirstName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("firstname");
                x.NotNullable(true);
            });

            Property(x => x.LastName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("lastname");
                x.NotNullable(true);
            });

            Property(x => x.UserName, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.Column("username");
            });

            Property(x => x.Email, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.Column("email");
                x.NotNullable(true);
            });

            Property(x => x.Phone, x =>
            {
                x.Length(15);
                x.Type(NHibernateUtil.String);
                x.Column("phone");
            });

            Property(x => x.Address, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.Column("address");
            });

            Property(x => x.Password, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("password");
                x.NotNullable(true);
            });

            Property(x => x.Status, x =>
            {
                x.Type(NHibernateUtil.Byte);
                x.Column("status");
                x.NotNullable(true);
            });

            Property(x => x.LastActivity, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.Column("lastactivity");
                x.NotNullable(true);
            });

            Property(x => x.Role, x =>
            {
                x.Length(30);
                x.Type(NHibernateUtil.String);
                x.Column("role");
            });
            Bag(user => user.Offers, map => map.Key(k => k.Column("userid")), rel => rel.OneToMany());
            Bag(user => user.Products, map => map.Key(k => k.Column("userid")), rel => rel.OneToMany());

            Table("user");
        }
    }
}
