using PaycoreFinalProject.Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace PaycoreFinalProject.Data.Mapping
{
    public class OfferMap : ClassMapping<Offer>
    {
        public OfferMap()
        {
            Id(x => x.OfferId, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("offerid");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(x => x.UserId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("userid");
                x.NotNullable(true);
            });

            Property(x => x.OfferedPrice, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.Column("offeredprice");
                x.NotNullable(true);
            });
            Property(x => x.OfferPercentage, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.Column("offerpercentage");
                x.NotNullable(true);
            });
            Property(x => x.OfferStatus, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.Column("offerstatus");
                x.NotNullable(true);
            });
            Property(x => x.IsActive, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.Column("isactive");
                x.NotNullable(true);
            });
            Property(x => x.OfferDate, x =>
            {
                x.Type(NHibernateUtil.Date);
                x.Column("offerdate");
                x.NotNullable(true);
            });

            ManyToOne(offer => offer.Product, map => map.Column("productid"));
            ManyToOne(offer => offer.User, map => map.Column("userId"));


            Table("offer");
        }
    }
}
