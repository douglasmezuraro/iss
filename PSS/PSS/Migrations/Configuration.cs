namespace PSS.Migrations
{
    using PSS.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SGCO.Context.Context>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SGCO.Context.Context context)
        {
            context.States.AddOrUpdate(state => state.Id,
                new State { Id = 01, UF = "AC", Name = "Acre", IsActive = true },
                new State { Id = 02, UF = "AL", Name = "Alagoas", IsActive = true },
                new State { Id = 03, UF = "AP", Name = "Amapá", IsActive = true },
                new State { Id = 04, UF = "AM", Name = "Amazonas", IsActive = true },
                new State { Id = 05, UF = "BA", Name = "Bahia", IsActive = true },
                new State { Id = 06, UF = "CE", Name = "Ceará", IsActive = true },
                new State { Id = 07, UF = "DF", Name = "Distrito Federal", IsActive = true },
                new State { Id = 08, UF = "ES", Name = "Espírito Santo", IsActive = true },
                new State { Id = 09, UF = "GO", Name = "Goiás", IsActive = true },
                new State { Id = 10, UF = "MA", Name = "Maranhão", IsActive = true },
                new State { Id = 11, UF = "MT", Name = "Mato Grosso", IsActive = true },
                new State { Id = 12, UF = "MS", Name = "Mato Grosso do Sul", IsActive = true },
                new State { Id = 13, UF = "MG", Name = "Minas Gerais", IsActive = true },
                new State { Id = 14, UF = "PA", Name = "Pará", IsActive = true },
                new State { Id = 15, UF = "PB", Name = "Paraíba", IsActive = true },
                new State { Id = 16, UF = "PR", Name = "Paraná", IsActive = true },
                new State { Id = 17, UF = "PE", Name = "Pernambuco", IsActive = true },
                new State { Id = 18, UF = "PI", Name = "Piauí", IsActive = true },
                new State { Id = 19, UF = "RJ", Name = "Rio de Janeiro", IsActive = true },
                new State { Id = 20, UF = "RN", Name = "Rio Grande do Norte", IsActive = true },
                new State { Id = 21, UF = "RS", Name = "Rio Grande do Sul", IsActive = true },
                new State { Id = 22, UF = "RO", Name = "Rondônia", IsActive = true },
                new State { Id = 23, UF = "RR", Name = "Roraima", IsActive = true },
                new State { Id = 24, UF = "SC", Name = "Santa Catarina", IsActive = true },
                new State { Id = 25, UF = "SP", Name = "São Paulo", IsActive = true },
                new State { Id = 26, UF = "SE", Name = "Sergipe", IsActive = true },
                new State { Id = 27, UF = "TO", Name = "Tocantins", IsActive = true });

            context.Cities.AddOrUpdate(city => city.Id,
                new City { Id = 1, Name = "Maringá", StateId = 16, IsActive = true });

            context.Genders.AddOrUpdate(gender => gender.Id,
                new Gender { Id = 1, Description = "Homem", IsActive = true },
                new Gender { Id = 2, Description = "Mulher", IsActive = true },
                new Gender { Id = 3, Description = "Indefinido", IsActive = true });

            context.UserTypes.AddOrUpdate(userType => userType.Id,
                new UserType { Id = 1, Description = "Administrador", IsActive = true },
                new UserType { Id = 2, Description = "Cliente", IsActive = true },
                new UserType { Id = 3, Description = "Visitante", IsActive = true });

            context.PaymentTypes.AddOrUpdate(paymentType => paymentType.Id,
                new PaymentType { Id = 1, Description = "Dinheiro", IsActive = true },
                new PaymentType { Id = 2, Description = "Cheque", IsActive = true },
                new PaymentType { Id = 3, Description = "Cartão de crédito", IsActive = true },
                new PaymentType { Id = 4, Description = "Cartão de débito", IsActive = true });

            context.OrderStatuses.AddOrUpdate(orderStatus => orderStatus.Id,
                new OrderStatus { Id = 1, Description = "Não finalizado" },
                new OrderStatus { Id = 2, Description = "Finalizado" },
                new OrderStatus { Id = 3, Description = "Em separação" },
                new OrderStatus { Id = 4, Description = "Saída para entrega" },
                new OrderStatus { Id = 5, Description = "Entregue" });

            context.FreightTypes.AddOrUpdate(freightType => freightType.Id,
                new FreightType { Id = 1, Description = "Sedex", IsActive = true },
                new FreightType { Id = 2, Description = "PAC", IsActive = true },
                new FreightType { Id = 3, Description = "Transportadora", IsActive = true });

            context.Units.AddOrUpdate(unit => unit.Id,
                new Unit { Id = 1, Description = "Peça", IsActive = true },
                new Unit { Id = 2, Description = "Caixa", IsActive = true },
                new Unit { Id = 3, Description = "Pacote", IsActive = true });
        }
    }
}
