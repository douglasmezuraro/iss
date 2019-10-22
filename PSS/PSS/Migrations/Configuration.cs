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
            SeedStates(context);
            SeedCities(context);
            SeedGenders(context);
            SeedUserTypes(context);
            SeedPaymentTypes(context);
            SeedOrderStatuses(context);
            SeedFreightTypes(context);
            SeedUnits(context);
            SeedCategories(context);
            SeedManufacturers(context);
            SeedProviders(context);
            SeedProducts(context);
        }

        private void SeedStates(SGCO.Context.Context context)
        {
            context.States.AddOrUpdate(s => s.Id,
                new State { Id = 01, UF = "AC", Name = "Acre" },
                new State { Id = 02, UF = "AL", Name = "Alagoas" },
                new State { Id = 03, UF = "AP", Name = "Amapá" },
                new State { Id = 04, UF = "AM", Name = "Amazonas" },
                new State { Id = 05, UF = "BA", Name = "Bahia" },
                new State { Id = 06, UF = "CE", Name = "Ceará" },
                new State { Id = 07, UF = "DF", Name = "Distrito Federal" },
                new State { Id = 08, UF = "ES", Name = "Espírito Santo" },
                new State { Id = 09, UF = "GO", Name = "Goiás" },
                new State { Id = 10, UF = "MA", Name = "Maranhão" },
                new State { Id = 11, UF = "MT", Name = "Mato Grosso" },
                new State { Id = 12, UF = "MS", Name = "Mato Grosso do Sul" },
                new State { Id = 13, UF = "MG", Name = "Minas Gerais" },
                new State { Id = 14, UF = "PA", Name = "Pará" },
                new State { Id = 15, UF = "PB", Name = "Paraíba" },
                new State { Id = 16, UF = "PR", Name = "Paraná" },
                new State { Id = 17, UF = "PE", Name = "Pernambuco" },
                new State { Id = 18, UF = "PI", Name = "Piauí" },
                new State { Id = 19, UF = "RJ", Name = "Rio de Janeiro" },
                new State { Id = 20, UF = "RN", Name = "Rio Grande do Norte" },
                new State { Id = 21, UF = "RS", Name = "Rio Grande do Sul" },
                new State { Id = 22, UF = "RO", Name = "Rondônia" },
                new State { Id = 23, UF = "RR", Name = "Roraima" },
                new State { Id = 24, UF = "SC", Name = "Santa Catarina" },
                new State { Id = 25, UF = "SP", Name = "São Paulo" },
                new State { Id = 26, UF = "SE", Name = "Sergipe" },
                new State { Id = 27, UF = "TO", Name = "Tocantins" });
        }

        private void SeedCities(SGCO.Context.Context context)
        {
            context.Cities.AddOrUpdate(c => c.Id,
                new City { Id = 01, StateId = 01, Name = "Rio Branco" },
                new City { Id = 02, StateId = 02, Name = "Maceió" },
                new City { Id = 03, StateId = 03, Name = "Macapá" },
                new City { Id = 04, StateId = 04, Name = "Manaus" },
                new City { Id = 05, StateId = 05, Name = "Salvador" },
                new City { Id = 06, StateId = 06, Name = "Fortaleza" },
                new City { Id = 07, StateId = 07, Name = "Brasília" },
                new City { Id = 08, StateId = 08, Name = "Vitória" },
                new City { Id = 09, StateId = 09, Name = "Goiânia" },
                new City { Id = 10, StateId = 10, Name = "São Luís" },
                new City { Id = 11, StateId = 11, Name = "Cuiabá" },
                new City { Id = 12, StateId = 12, Name = "Campo Grande" },
                new City { Id = 13, StateId = 13, Name = "Belo Horizonte" },
                new City { Id = 14, StateId = 14, Name = "Belém" },
                new City { Id = 15, StateId = 15, Name = "João Pessoa" },
                new City { Id = 16, StateId = 16, Name = "Curitiba" },
                new City { Id = 17, StateId = 17, Name = "Recife" },
                new City { Id = 18, StateId = 18, Name = "Teresina" },
                new City { Id = 19, StateId = 19, Name = "Rio de Janeiro" },
                new City { Id = 20, StateId = 20, Name = "Natal" },
                new City { Id = 21, StateId = 21, Name = "Porto Alegre" },
                new City { Id = 22, StateId = 22, Name = "Porto Velho" },
                new City { Id = 23, StateId = 23, Name = "Boa Vista" },
                new City { Id = 24, StateId = 24, Name = "Florianópolis" },
                new City { Id = 25, StateId = 25, Name = "São Paulo" },
                new City { Id = 26, StateId = 26, Name = "Aracaju" },
                new City { Id = 27, StateId = 27, Name = "Palmas" },
                new City { Id = 28, StateId = 16, Name = "Maringá" },
                new City { Id = 29, StateId = 25, Name = "São Bernardo do Campo" },
                new City { Id = 30, StateId = 25, Name = "Presidente Prudente" });
        }

        private void SeedGenders(SGCO.Context.Context context)
        {
            context.Genders.AddOrUpdate(g => g.Id,
                new Gender { Id = 1, Description = "Homem" },
                new Gender { Id = 2, Description = "Mulher" },
                new Gender { Id = 3, Description = "Indefinido" });
        }

        private void SeedUserTypes(SGCO.Context.Context context)
        {
            context.UserTypes.AddOrUpdate(u => u.Id,
                new UserType { Id = 1, Description = "Administrador" },
                new UserType { Id = 2, Description = "Cliente" },
                new UserType { Id = 3, Description = "Visitante" });
        }

        private void SeedPaymentTypes(SGCO.Context.Context context)
        {
            context.PaymentTypes.AddOrUpdate(p => p.Id,
                new PaymentType { Id = 1, Description = "Dinheiro" },
                new PaymentType { Id = 2, Description = "Cheque" },
                new PaymentType { Id = 3, Description = "Cartão de crédito" },
                new PaymentType { Id = 4, Description = "Cartão de débito" });
        }

        private void SeedOrderStatuses(SGCO.Context.Context context)
        {
            context.OrderStatuses.AddOrUpdate(o => o.Id,
                new OrderStatus { Id = 1, Description = "Não finalizado" },
                new OrderStatus { Id = 2, Description = "Finalizado" },
                new OrderStatus { Id = 3, Description = "Em separação" },
                new OrderStatus { Id = 4, Description = "Saída para entrega" },
                new OrderStatus { Id = 5, Description = "Entregue" });
        }

        private void SeedFreightTypes(SGCO.Context.Context context)
        {
            context.FreightTypes.AddOrUpdate(f => f.Id,
                new FreightType { Id = 1, Description = "Correios" },           
                new FreightType { Id = 2, Description = "Transportadora" });
        }

        private void SeedUnits(SGCO.Context.Context context)
        {
            context.Units.AddOrUpdate(u => u.Id,
                new Unit { Id = 1, Description = "Peça" },
                new Unit { Id = 2, Description = "Caixa" },
                new Unit { Id = 3, Description = "Pacote" });
        }

        private void SeedCategories(SGCO.Context.Context context)
        {
            context.Categories.AddOrUpdate(c => c.Id,
                new Category { Id = 1, IsPerishable = false, Name = "Guitarra" },
                new Category { Id = 2, IsPerishable = false, Name = "Violão" },
                new Category { Id = 3, IsPerishable = false, Name = "Baixo" },
                new Category { Id = 4, IsPerishable = false, Name = "Bateria" },
                new Category { Id = 5, IsPerishable = false, Name = "Teclado" },
                new Category { Id = 6, IsPerishable = false, Name = "Piano" },
                new Category { Id = 7, IsPerishable = false, Name = "Saxofone" });
        }

        private void SeedManufacturers(SGCO.Context.Context context)
        {
            context.Manufacturers.AddOrUpdate(m => m.Id,
                new Manufacturer
                {
                    Id = 1,
                    ShortName = "Fender",
                    FullName = "Fender Musical Instruments Corporation",
                    CNPJ = "12.443.211/0001-88",
                    Phone = "(11) 3892-0433",
                    Email = "contato@fender.com.br",
                    Address = "Rua Arandu, 205 - Brooklin Novo - São Paulo-SP",
                    Complement = "Ed. Berrini Business Center",
                    Number = 205,
                    PostalCode = "04562-030",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 2,
                    ShortName = "Gibson",
                    FullName = "Gibson Brands, Inc.",
                    CNPJ = "88.564.586/0001-68",
                    Phone = "(11) 2191-2850",
                    Email = "contato@gibson.com.br",
                    Address = "Av. Jabaquara, 2049 - Mirandópolis - São Paulo-SP",
                    Complement = null,
                    Number = 2049,
                    PostalCode = "04045-003",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 3,
                    ShortName = "Tagima",
                    FullName = "Marutec Ind. Com. Imp. Exp. Ltda.",
                    CNPJ = "52.252.278/0001-50",
                    Phone = "(11) 4343-2900",
                    Email = "contato@tagima.com.br",
                    Address = "Estrada Sadae Takagi, 1950 - Cooperativa - São Bernardo do Campo-SP",
                    Complement = "Cooperativa",
                    Number = 1950,
                    PostalCode = "09852-070",
                    CityId = 29
                },
                new Manufacturer
                {
                    Id = 4,
                    ShortName = "Takamine",
                    FullName = "Takamine Gakki Seisakusho, Ltda.",
                    CNPJ = "27.196.854/0001-41",
                    Phone = "(18) 3941-2022",
                    Email = "contato@takamine.com.br",
                    Address = "Rodovia Raposo Tavares, 242 - KM 555 - Presidente Prudente-SP",
                    Complement = "KM 555",
                    Number = 242,
                    PostalCode = "19570-000",
                    CityId = 30
                });
        }

        private void SeedProviders(SGCO.Context.Context context)
        {
            context.Providers.AddOrUpdate(p => p.Id,
                new Provider
                {
                    Id = 1,
                    ShortName = "Marutec",
                    FullName = "Marutec Ind. Com. Imp. Exp. Ltda.",
                    CNPJ = "52.252.278/0001-50",
                    Phone = "(11) 4343-2900",
                    Email = "contato@marutec.com.br",
                    Address = "Estrada Sadae Takagi, 1950 - Cooperativa - São Bernardo do Campo-SP",
                    Complement = "Cooperativa",
                    Number = 1950,
                    PostalCode = "09852-070",
                    CityId = 29
                },
                new Provider
                {
                    Id = 2,
                    ShortName = "Musitech",
                    FullName = "Musitech Instrumentos Musicais, Ltda.",
                    CNPJ = "66.652.569/0001-40",
                    Phone = "(44) 3034-7057",
                    Email = "contato@musitechinstrumentos.com.br",
                    Address = "Av. Herval, 695 - Centro - Maringá-PR",
                    Complement = null,
                    Number = 695,
                    PostalCode = "87013-110",
                    CityId = 28
                });
        }

        private void SeedProducts(SGCO.Context.Context context)
        {
            context.Products.AddOrUpdate(p => p.Id,
                new Product
                {
                    Id = 1,
                    Description = "Fender Stratocaster Stardard - Artic White",
                    PurchasePrice = 1788.00,
                    SalePrice = 5364.00,
                    Stock = 3,
                    Weight = 3.6,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    ProviderId = 2,
                    UnitId = 1
                },
                new Product
                {
                    Id = 2,
                    Description = "Gibson Les Paul Traditional - Honery Burst",
                    PurchasePrice = 2967.00,
                    SalePrice = 8901.00,
                    Stock = 5,
                    Weight = 4.2,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 2,
                    ProviderId = 2,
                    UnitId = 1
                },
                new Product
                {
                    Id = 3,
                    Description = "Violão Tagima Dallas T - Sunburst",
                    PurchasePrice = 209.33,
                    SalePrice = 628.00,
                    Stock = 10,
                    Weight = 1.2,
                    Expiration = null,
                    CategoryId = 2,
                    ManufacturerId = 3,
                    ProviderId = 1,
                    UnitId = 1
                },
                new Product
                {
                    Id = 4,
                    Description = "Violão Takamine EF340S TT & TLD",
                    PurchasePrice = 3207.00,
                    SalePrice = 9621.00,
                    Stock = 1,
                    Weight = 1.5,
                    Expiration = null,
                    CategoryId = 2,
                    ManufacturerId = 4,
                    ProviderId = 1,
                    UnitId = 1
                });
        }
    }
}
