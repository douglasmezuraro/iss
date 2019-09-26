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
                new State { UF = "AC", Name = "Acre", IsActive = true },
                new State { UF = "AL", Name = "Alagoas", IsActive = true },
                new State { UF = "AP", Name = "Amapá", IsActive = true },
                new State { UF = "AM", Name = "Amazonas", IsActive = true },
                new State { UF = "BA", Name = "Bahia", IsActive = true },
                new State { UF = "CE", Name = "Ceará", IsActive = true },
                new State { UF = "DF", Name = "Distrito Federal", IsActive = true },
                new State { UF = "ES", Name = "Espírito Santo", IsActive = true },
                new State { UF = "GO", Name = "Goiás", IsActive = true },
                new State { UF = "MA", Name = "Maranhão", IsActive = true },
                new State { UF = "MT", Name = "Mato Grosso", IsActive = true },
                new State { UF = "MS", Name = "Mato Grosso do Sul", IsActive = true },
                new State { UF = "MG", Name = "Minas Gerais", IsActive = true },
                new State { UF = "PA", Name = "Pará", IsActive = true },
                new State { UF = "PB", Name = "Paraíba", IsActive = true },
                new State { UF = "PR", Name = "Paraná", IsActive = true },
                new State { UF = "PE", Name = "Pernambuco", IsActive = true },
                new State { UF = "PI", Name = "Piauí", IsActive = true },
                new State { UF = "RJ", Name = "Rio de Janeiro", IsActive = true },
                new State { UF = "RN", Name = "Rio Grande do Norte", IsActive = true },
                new State { UF = "RS", Name = "Rio Grande do Sul", IsActive = true },
                new State { UF = "RO", Name = "Rondônia", IsActive = true },
                new State { UF = "RR", Name = "Roraima", IsActive = true },
                new State { UF = "SC", Name = "Santa Catarina", IsActive = true },
                new State { UF = "SP", Name = "São Paulo", IsActive = true },
                new State { UF = "SE", Name = "Sergipe", IsActive = true },
                new State { UF = "TO", Name = "Tocantins", IsActive = true });

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
                new OrderStatus { Id = 1, Description = "Não finalizado", IsActive = true },
                new OrderStatus { Id = 2, Description = "Finalizado", IsActive = true },
                new OrderStatus { Id = 3, Description = "Em separação", IsActive = true },
                new OrderStatus { Id = 4, Description = "Saída para entrega", IsActive = true },
                new OrderStatus { Id = 5, Description = "Entregue", IsActive = true });

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
