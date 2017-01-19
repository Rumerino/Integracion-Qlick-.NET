using eSmash.Models;
using eSmash.Util;
using QlikSense;

namespace eSmash.Qlik
{
    public class IFSA : QlikApp
    {

        public IFSA()
           : base(ConfigReader.getQlikConfigValue("APPIDIFSA"), "IFSA")
        {

            addChilds(
                market(),
                Passengers(),
                Yield(),
                Revenue(),
                agentrevenue(),
                routepassenger(),
                agentrpassenger(),
                APAnalysis(),
                classAnalysis(),
                performance(),
                reporting()
               );
        }


        private QlikSheet market()
        {
            //                     (IDHOJA,NAME)
            var sheet = new QlikSheet("fe563c9b-e5ba-4820-85cc-7279e84d4d15", "market");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                 //formato:           (ID, NAME)
                 new QlikVisualization("UNbjh", "obj1"),
                //calculo del 1 sobre total
                new QlikVisualization("reQhYe", "obj11"),
                //calculo del uno YOY
                new QlikVisualization("4ed2845b-2939-46d0-9888-6bd449a29f6a", "obj12"),
                 //objeto cabecera 2
                 new QlikVisualization("CZGBPjV", "obj2"),
                new QlikVisualization("PKQRFP", "obj21"),
                new QlikVisualization("a4684ee4-5cfa-43ab-b8b1-db220fb25a07", "obj22"),
                 new QlikVisualization("38b4b45e-a8e9-456a-9526-a42ad0f19d96", "obj3"),
                new QlikVisualization("b6633fa7-5674-4229-b6ba-3195de3500c2", "obj4"),
                new QlikVisualization("EqFA", "obj5Title"),
                 new QlikVisualization("XpPtUpe", "obj5"),
                new QlikVisualization("ePgmQW", "obj5Title"),
                new QlikVisualization("26998d1b-c634-40a0-b594-f3d440ae03d3", "obj6")
                );
            return sheet;
        }
        private QlikSheet Passengers()
        {
            var sheet = new QlikSheet("26998d1b-c634-40a0-b594-f3d440ae03d3", "Passengers");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                 //formato:           (ID, NAME)
                 new QlikVisualization("VDMYq", "obj1"),
                new QlikVisualization("39944732-7a59-457e-a2af-99f8128a6e46", "obj11"),
                new QlikVisualization("XvAjjjB", "obj12"),
                 new QlikVisualization("mZJRSw", "obj2"),
                new QlikVisualization("3b713d35-543c-4c20-90eb-4a2d71fbe7d2", "obj21"),
                new QlikVisualization("8ee870de-5e89-488c-9f27-af3f0587d68c", "obj22"),

                new QlikVisualization("dd3838ae-f63a-449f-a3aa-468808438f54", "obj3"),
                new QlikVisualization("5d1659cc-7ca8-4b5b-84d3-a9e67cec7762", "obj4"),
                new QlikVisualization("JaEVwQ", "obj5Title"),
                new QlikVisualization("CLKGerm", "obj5"),
                new QlikVisualization("FdnUSjU", "obj6Title"),
                new QlikVisualization("9aafd9e5-6c20-4639-be78-d496d50e660e", "obj6")
                );
            return sheet;
        }

        private QlikSheet Yield()
        {
            var sheet = new QlikSheet("17be2d8e-0112-4bda-86a1-f35136c40213", "Yield");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                 //formato:           (ID, NAME)
                 new QlikVisualization("PAUaJMm", "obj1"),
                new QlikVisualization("SmfdDvZ", "obj11"),
                new QlikVisualization("a6b45e07-764e-42a2-be55-4c440aa447dd", "obj12"),
                 new QlikVisualization("mjVJxpd", "obj2"),
                new QlikVisualization("fGyAK", "obj21"),
                new QlikVisualization("EgFjwp", "obj22"),

                new QlikVisualization("cca42ddb-3528-41ab-af7b-367a0326fb70", "obj3"),
                new QlikVisualization("180e48ca-e1b6-406a-a8c9-9740ae4ad55a", "obj4"),
                new QlikVisualization("MSjcm", "obj5Title"),
                new QlikVisualization("3f6b07ae-5188-431e-9fbe-bd01494f4cad", "obj5"),
                new QlikVisualization("hAjWfdM", "obj6Title"),
                new QlikVisualization("66b3ca37-a069-47d3-9a25-a514ebd5eef0", "obj6")
                );
            return sheet;
        }

        private QlikSheet Revenue()
        {
            var sheet = new QlikSheet("ad0424c4-8c34-4de6-b512-e5e29f489034", "Revenue");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                 //formato:           (ID, NAME)
                 new QlikVisualization("YjLsm", "obj1"),
                new QlikVisualization("TbbSLx", "obj11"),
                new QlikVisualization("BzCvtJB", "obj12"),
                 new QlikVisualization("AfdpJJc", "obj2"),
                new QlikVisualization("aswRef", "obj21"),
                new QlikVisualization("tTEEj", "obj22"),
                 new QlikVisualization("NaxNeEe", "obj3"),
                new QlikVisualization("gQWmqh", "obj31"),
                new QlikVisualization("tcPVfF", "obj32"),
                 new QlikVisualization("mnesfN", "obj4"),
                new QlikVisualization("DBPUJH", "obj41"),
                new QlikVisualization("Evzmba", "obj42"),
                 new QlikVisualization("BUFK", "obj5"),
                new QlikVisualization("uFmJYrd", "obj51"),
                new QlikVisualization("CjJCdk", "obj52"),
                 new QlikVisualization("AYdWaDD", "obj6"),
                new QlikVisualization("uFmJYrd", "obj61"),
                new QlikVisualization("XQVTqr", "obj62"),

                new QlikVisualization("unPkzL", "obj7"),
                new QlikVisualization("pRbFy", "obj8"),
                new QlikVisualization("rPmL", "obj9")
                );
            return sheet;
        }



        private QlikSheet routepassenger()
        {
            var sheet = new QlikSheet("2fd57181-f0ed-47a4-b09b-abfbeae212d4", "routepassenger");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                //formato:           (ID, NAME)
                new QlikVisualization("LYXaz", "obj1"),
                new QlikVisualization("6122c127-e736-46a1-ba2f-4bcf0c7bf43f", "obj11"),
                new QlikVisualization("LEct", "obj12"),
                new QlikVisualization("jTRchjF", "obj2"),
                new QlikVisualization("8b56f1f3-06a7-43eb-9262-35c6934b2b43", "obj21"),
                new QlikVisualization("e878ed07-c67d-48b0-b15c-3162fe26cf9f", "obj22"),
                 new QlikVisualization("jjppWG", "obj3"),
                new QlikVisualization("e480dcd8-80af-4a13-8a8f-e4f4ebd8a344", "obj31"),
                new QlikVisualization("07b39dff-1f2f-4c01-8f71-ab119da9b02f", "obj32"),
                 new QlikVisualization("jHQp", "obj4"),
                new QlikVisualization("af9e038c-9dfc-4752-9565-8eac254890a0", "obj41"),
                new QlikVisualization("3510afa1-9e3b-42eb-891c-55d98aefe828", "obj42"),
                 new QlikVisualization("yrgPpm", "obj5"),
                new QlikVisualization("gTCCeQ", "obj51"),
                new QlikVisualization("jUXhkyY", "obj52"),
                 new QlikVisualization("LsbQjax", "obj6"),
                new QlikVisualization("yKSE", "obj61"),
                new QlikVisualization("99467bfe-1819-4497-83d3-957323c0a3bd", "obj62"),

                new QlikVisualization("XXamPj", "obj7"),
                new QlikVisualization("SFAeyh", "obj8"),
                new QlikVisualization("beETN", "obj9")
                );
            return sheet;
        }

        private QlikSheet agentrevenue()
        {
            var sheet = new QlikSheet("55f41b5f-ab44-4a82-8a6a-23674036beaa", "agentrevenue");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                //formato:           (ID, NAME)
                new QlikVisualization("GRpps", "obj1"),
                new QlikVisualization("046dd80a-09bb-4ba7-9d2e-de11931b224e", "obj11"),
                new QlikVisualization("wPmFc", "obj12"),
                new QlikVisualization("vSAb", "obj2"),
                new QlikVisualization("d6e83f84-eedc-407a-a944-a3aef6982e62", "obj21"),
                new QlikVisualization("42a8c47f-d805-4270-9e1d-cc6127e4ec23", "obj22"),
                 new QlikVisualization("CtPPXpa", "obj3"),
                new QlikVisualization("e2f160c9-ead7-4889-936a-e33905579ea9", "obj31"),
                new QlikVisualization("480a17fa-4c87-4317-9d27-66157b06fc90", "obj32"),
                 new QlikVisualization("apRerd", "obj4"),
                new QlikVisualization("4e3130c4-eb64-4ebd-adfa-4b08777a0de6", "obj41"),
                new QlikVisualization("5582ab11-55ca-4f4f-9bcf-345f935e754a", "obj42"),
                 new QlikVisualization("YfabP", "obj5"),
                new QlikVisualization("PbpZpC", "obj51"),
                new QlikVisualization("jBnS", "obj52"),
                 new QlikVisualization("bCzwUe", "obj6"),
                new QlikVisualization("pNsxRV", "obj61"),
                new QlikVisualization("45f6275b-3d51-47f7-8998-790fceeb0f58", "obj62"),

                new QlikVisualization("PZAvt", "obj7"),
                new QlikVisualization("pMpJXxt", "obj8"),
                new QlikVisualization("LmeqE", "obj9")
                );
            return sheet;
        }
        private QlikSheet agentrpassenger()
        {
            var sheet = new QlikSheet("92301427-4e77-46a4-ad76-9ca1fdcd53e9", "agentrpassenger");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                //formato:           (ID, NAME)
                new QlikVisualization("QcvE", "obj1"),
                new QlikVisualization("591ec16c-0339-4520-84e0-069ca1e8e1d8", "obj11"),
                new QlikVisualization("bFXSJm", "obj12"),
                new QlikVisualization("zWPYyWP", "obj2"),
                new QlikVisualization("17f30c49-d559-41ac-b020-10a79d3353d7", "obj21"),
                new QlikVisualization("8b11e123-b481-45bf-b1d9-f86463564389", "obj22"),
                 new QlikVisualization("JPpBcX", "obj3"),
                new QlikVisualization("9699221a-3cd0-45de-a764-20c1d5575412", "obj31"),
                new QlikVisualization("137e3faf-c359-4489-8f44-a996b0396232", "obj32"),
                 new QlikVisualization("nqKJTV", "obj4"),
                new QlikVisualization("50e6a571-b868-4914-a0d8-91c7e36fcaf9", "obj41"),
                new QlikVisualization("ec7ae202-eff6-44f2-b9eb-4597978592e7", "obj42"),
                 new QlikVisualization("pQnkkq", "obj5"),
                new QlikVisualization("KEPb", "obj51"),
                new QlikVisualization("UcYx", "obj52"),
                 new QlikVisualization("dSXjch", "obj6"),
                new QlikVisualization("PaAEe", "obj61"),
                new QlikVisualization("1d07c162-b221-4800-bd73-9e9eb78d4dfa", "obj62"),

                new QlikVisualization("BPmPS", "obj7"),
                new QlikVisualization("PvCuEEq", "obj8"),
                new QlikVisualization("bPsyVs", "obj9")
                );
            return sheet;
        }
        private QlikSheet APAnalysis()
        {
            var sheet = new QlikSheet("f067d40c-6a55-494f-af1b-4fc2c8a3059a", "APAnalysis");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                //formato:           (ID, NAME)
                new QlikVisualization("1b5209cd-27b1-4cda-b3b6-9784fa3bcd58", "obj1"),
                new QlikVisualization("56d695ac-6ccf-4764-9eed-f182e41422a7", "obj11"),
                new QlikVisualization("22d20465-85d0-42fa-bb68-f9fd17df7585", "obj12"),
                new QlikVisualization("4b83ff32-928d-4c9c-b98f-c17264f7e8b7", "obj2"),
                new QlikVisualization("0eadcae1-f67f-4bc1-917a-7a229ddd1237", "obj21"),
                new QlikVisualization("0eadcae1-f67f-4bc1-917a-7a229ddd1237", "obj22"),
                 new QlikVisualization("86e3e9fa-3d32-4945-9357-6eb8ca0d54c1", "obj3"),
                new QlikVisualization("5cf6fc5d-0a1b-4273-9286-bc17f42d9146", "obj31"),
                new QlikVisualization("ab830528-99f8-47d4-828d-25f161c2b540", "obj32"),
                 new QlikVisualization("82e6e4bb-f08e-44bf-8282-d0305816ad30", "obj4"),
                new QlikVisualization("bc1ac770-b67c-434c-9a6b-6072fbd937be", "obj41"),
                new QlikVisualization("716f17dd-9bff-4900-86cb-a35b58fc16f7", "obj42"),
                 new QlikVisualization("12ae6ce3-bef6-471e-9c3e-7f17f6beb4b6", "obj5"),
                new QlikVisualization("7a45da59-c7d8-4080-a7c4-cfd81555c19f", "obj51"),
                new QlikVisualization("7a45da59-c7d8-4080-a7c4-cfd81555c19f", "obj52"),
                 new QlikVisualization("17a5f9f6-c463-44b6-a913-d26e10a77aae", "obj6"),
                new QlikVisualization("fc064fcf-85a8-4792-bbc1-ebb98c40844b", "obj61"),
                new QlikVisualization("6b3074b1-e0f7-4b20-9a56-403910a4c50f", "obj62"),

                new QlikVisualization("UjNVGph", "obj7Title"),
                new QlikVisualization("SjLp", "obj7"),
                new QlikVisualization("FxMkvBL", "obj8Title"),
                new QlikVisualization("xRVPr", "obj8"),
                new QlikVisualization("LujjS", "obj9"),
                new QlikVisualization("DbMNzN", "obj10")
                );
            return sheet;
        }

        private QlikSheet classAnalysis()
        {
            var sheet = new QlikSheet("5a13bc06-81e5-446d-be45-6b698fab6ebd", "classAnalysis");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                //formato:           (ID, NAME)
                new QlikVisualization("gtJTG", "obj1"),
                new QlikVisualization("40958605-cd0d-4abb-8283-ac663c574ead", "obj11"),
                new QlikVisualization("HXPnvng", "obj12"),
                new QlikVisualization("dGCF", "obj2"),
                new QlikVisualization("00886d98-6e0e-4362-95b0-092b927328a2", "obj21"),
                new QlikVisualization("c649f3ba-f06c-419c-8b38-d26de0f20146", "obj22"),
                 new QlikVisualization("DhsmebJ", "obj3"),
                new QlikVisualization("c649f3ba-f06c-419c-8b38-d26de0f20146", "obj31"),
                new QlikVisualization("a318892c-15df-45c6-90dc-5ac7c9044719", "obj32"),
                 new QlikVisualization("YaZFgQy", "obj4"),
                new QlikVisualization("a318892c-15df-45c6-90dc-5ac7c9044719", "obj41"),
                new QlikVisualization("dc89653c-8c71-401b-80c9-fd6bc593670a", "obj42"),
                 new QlikVisualization("YCKfSJH", "obj5"),
                new QlikVisualization("Srnj", "obj51"),
                new QlikVisualization("PCVPsaF", "obj52"),
                 new QlikVisualization("XjLjxe", "obj6"),
                new QlikVisualization("pWCQrmG", "obj61"),
                new QlikVisualization("e0e971ec-3aff-4066-ba98-aa0a98a38b8d", "obj62"),

                new QlikVisualization("qDMrZz", "obj7Title"),
                new QlikVisualization("cJsQBV", "obj7"),
                new QlikVisualization("dYpL", "obj8Title"),
                new QlikVisualization("ggHZ", "obj8"),
                new QlikVisualization("VQvGypj", "obj9Title"),
                new QlikVisualization("PJPp", "obj9"),
                new QlikVisualization("jjBH", "obj10Title"),
                new QlikVisualization("UxrhjP", "obj10")
                );
            return sheet;
        }

        private QlikSheet performance()
        {
            var sheet = new QlikSheet("50b10d33-dcd6-4661-baed-9c0c80b09033", "performance");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                //formato:           (ID, NAME)
                new QlikVisualization("JALamgp", "obj1"),
                new QlikVisualization("b00931a9-72a2-4626-ad15-f16ac1f049e3", "obj11"),
                new QlikVisualization("cJXTqW", "obj12"),
                new QlikVisualization("xzqGysG", "obj2"),
                new QlikVisualization("60fd60ae-01e6-4776-aadc-0e87dc3b91ab", "obj21"),
                new QlikVisualization("902b5fc7-1c01-4877-8612-17ebd6ec479d", "obj22"),
                 new QlikVisualization("jVhcX", "obj3"),
                new QlikVisualization("94b72b14-28d0-4817-8d62-97fed69ff02f", "obj31"),
                new QlikVisualization("ffaf24f4-5ace-4738-826f-e2598e2e0e20", "obj32"),
                 new QlikVisualization("RZQjwzc", "obj4"),
                new QlikVisualization("ccf2f1ca-b489-4456-bcb1-37d7612af2ce", "obj41"),
                new QlikVisualization("fbd2ec1b-35fd-47c6-a84b-7fc799b2fe53", "obj42"),
                 new QlikVisualization("afsynKu", "obj5"),
                new QlikVisualization("qcfn", "obj51"),
                new QlikVisualization("TjEVgEy", "obj52"),
                 new QlikVisualization("MExFhPa", "obj6"),
                new QlikVisualization("MPyEf", "obj61"),
                new QlikVisualization("d4751972-5154-4265-a014-1e664787637c", "obj62"),

                new QlikVisualization("rpbnTBd", "obj7"),
                new QlikVisualization("aNqJG", "obj8")
                );
            return sheet;
        }

        private QlikSheet reporting()
        {
            var sheet = new QlikSheet("5fcbcfd8-3d36-49cd-9a0f-0c7d476a0a46", "reporting");

            sheet.addChilds(
                //filtros genericos
                new QlikVisualization("eWJgem", "FilterPane_Filters_General"),
                new QlikVisualization("UPUUzV", "FilterPane_Filters_Period"),
                new QlikVisualization("tjQjxN", "FilterPane_Filters_Agent"),
                new QlikVisualization("DmVjhL", "FilterPane_Filters_OD"),
                new QlikVisualization("JDaqpLg", "FilterPane_Filters_Other"),
                //filtros preseleccionados
                new QlikVisualization("njjJa", "FilterPane_Filters_1"),
                new QlikVisualization("JPYBvpe", "FilterPane_Filters_2"),
                new QlikVisualization("nfptrz", "FilterPane_Filters_3"),
                new QlikVisualization("RafjkS", "FilterPane_Filters_4"),

                //formato:           (ID, NAME)
                new QlikVisualization("uPLjDP", "obj1"),
                new QlikVisualization("1cba0fea-572a-4135-a7a2-cfa84c15333b", "obj11"),
                new QlikVisualization("c8b3ec84-bb18-45db-9e64-35001b3c2ae1", "obj12"),
                new QlikVisualization("zEnSh", "obj2"),
                new QlikVisualization("dfce2a7e-ef9a-4cba-aa97-d00aef48f135", "obj21"),
                new QlikVisualization("1c9ec882-f757-4e92-985e-e91ba1da121a", "obj22"),
                 new QlikVisualization("XHDA", "obj3"),
                new QlikVisualization("5c908796-6349-49df-b158-c5b91ed46fb8", "obj31"),
                new QlikVisualization("e9229550-a28c-4fbd-88d9-399b2d419538", "obj32"),
                 new QlikVisualization("cKYw", "obj4"),
                new QlikVisualization("d3408150-747b-4492-864e-a8d15e1b42b1", "obj41"),
                new QlikVisualization("74263138-029e-4e90-a3b7-6688b5c7e9ac", "obj42"),
                 new QlikVisualization("MrEJwP", "obj5"),
                new QlikVisualization("b7af59fa-80ff-4484-8f2b-1935c54a5ce5", "obj51"),
                new QlikVisualization("735e258f-e236-4364-9c2e-e59103d8cbbd", "obj52"),
                 new QlikVisualization("drfMzME", "obj6"),
                new QlikVisualization("3a92cdf1-f61c-4cbc-9111-0200814e661b", "obj61"),
                new QlikVisualization("5e386076-e0f7-450d-aabd-2fca75e74c52", "obj62"),

                new QlikVisualization("muDgZnS", "obj7")
                );
            return sheet;
        }
    }
}

