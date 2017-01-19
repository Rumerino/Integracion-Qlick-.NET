using eSmash.Models;
using eSmash.Util;
using QlikSense;
using System.Collections.Generic;

namespace eSmash.Qlik
{
    public class ISA : QlikApp
    {
        private const string REVENUESHARE = "REVENUESHARE";
        private const string REVENUE = "REVENUE";
        private const string PAX = "PAX";
        private const string PASSENGER = "PASSENGER";
        private const string YIELD = "YIELD";
        private const string YIELDVSINDUSTRY = "YIELDVSINDUSTRY";
        public ISA()
            : base(ConfigReader.getQlikConfigValue("APPID"), "ISA")
        {

            addChilds(
                market(),
                Passengers(),
                Yield(),
                Revenue(),
                agentrevenue(),
                routepassenger(),
                agentrpassenger(),
                classAnalysis(),
                performance(),
                reporting()
               );
        }

        private QlikVisualization[] getMasterFilters()
        {
            QlikVisualization[] FilterVisualization = new QlikVisualization[8];

            FilterVisualization[0] = (new QlikVisualization("TxcRWQ", "FilterPane_Filters_Agent"));
            FilterVisualization[1] = (new QlikVisualization("jBTR", "FilterPane_Filters_General"));
            FilterVisualization[2] = (new QlikVisualization("JJJJEW", "FilterPane_Filters_OD"));
            FilterVisualization[3] = (new QlikVisualization("bHJPjJK", "FilterPane_Filters_Other"));
            FilterVisualization[4] = (new QlikVisualization("Skgmfm", "FilterPane_Filters_1"));
            FilterVisualization[5] = (new QlikVisualization("DZQCF", "FilterPane_Filters_2"));
            FilterVisualization[6] = (new QlikVisualization("DGrD", "FilterPane_Filters_3"));
            FilterVisualization[7] = (new QlikVisualization("mkjmT", "FilterPane_Filters_4"));

            return FilterVisualization;
        }
        private QlikVisualization[] getMasterItems(string item, string possition)
        {
             QlikVisualization[] KIPVisualization = new QlikVisualization[3];
             switch (item)
            {
                case "REVENUESHARE":
                    KIPVisualization[0]=(new QlikVisualization("MYMsk", "obj"+ possition));
                    KIPVisualization[1] = (new QlikVisualization("TajcMxG", "obj"+ possition + "1"));
                    KIPVisualization[2] = (new QlikVisualization("mWMyJX", "obj" + possition + "2"));
                    break;
                case "REVENUE":
                    KIPVisualization[0] = (new QlikVisualization("hUn", "obj" + possition));
                    KIPVisualization[1] = (new QlikVisualization("hETJG", "obj" + possition + "1"));
                    KIPVisualization[2] = (new QlikVisualization("XKmaE", "obj" + possition + "2"));
                    break;
                case "PAX":
                    KIPVisualization[0] = (new QlikVisualization("QKD", "obj" + possition));
                    KIPVisualization[1] = (new QlikVisualization("pTpkE", "obj" + possition + "1"));
                    KIPVisualization[2] = (new QlikVisualization("bWuYB", "obj" + possition + "2"));
                    break;
                case "PASSENGER":
                    KIPVisualization[0] = (new QlikVisualization("JKxVNU", "obj" + possition));
                    KIPVisualization[1] = (new QlikVisualization("ntFGYaC", "obj" + possition + "1"));
                    KIPVisualization[2] = (new QlikVisualization("ddJZ", "obj" + possition + "2"));
                    break;
                case "YIELD":
                    KIPVisualization[0] = (new QlikVisualization("AWVaT", "obj" + possition));
                    KIPVisualization[1] = (new QlikVisualization("aRdQs", "obj" + possition + "1"));
                    KIPVisualization[2] = (new QlikVisualization("ndPA", "obj" + possition + "2"));
                    break;
                case "YIELDVSINDUSTRY":
                    KIPVisualization[0] = (new QlikVisualization("gjXvM", "obj" + possition));
                    KIPVisualization[1] = (new QlikVisualization("CVnRR", "obj" + possition + "1"));
                    KIPVisualization[2] = (new QlikVisualization("pPtYZVw", "obj" + possition + "2"));
                    break;
            }


            return KIPVisualization;
        }

        private QlikSheet market()
        {
            var sheet = new QlikSheet("fe563c9b-e5ba-4820-85cc-7279e84d4d15", "market");


            sheet.addChilds(getMasterItems(REVENUESHARE, "1"));
            sheet.addChilds(getMasterItems(REVENUE, "2"));
            sheet.addChilds(getMasterFilters());
            
            sheet.addChilds(
            
                new QlikVisualization("38b4b45e-a8e9-456a-9526-a42ad0f19d96", "obj3"), 
                new QlikVisualization("b6633fa7-5674-4229-b6ba-3195de3500c2", "obj4"),
                new QlikVisualization("XpPtUpe", "obj5"),
                new QlikVisualization("26998d1b-c634-40a0-b594-f3d440ae03d3", "obj6")
                );
            return sheet;
        }
        private QlikSheet Passengers()
        {
            var sheet = new QlikSheet("fe3b0382-f5de-4cc4-929e-4d1aadbce64c", "Passengers");
            sheet.addChilds(getMasterItems(PAX, "1"));
            sheet.addChilds(getMasterItems(PASSENGER, "2"));
            sheet.addChilds(getMasterFilters());
            sheet.addChilds(
                new QlikVisualization("5d1659cc-7ca8-4b5b-84d3-a9e67cec7762", "obj4"),
                new QlikVisualization("dd3838ae-f63a-449f-a3aa-468808438f54", "obj3"),
                new QlikVisualization("CLKGerm", "obj5"),
                new QlikVisualization("9aafd9e5-6c20-4639-be78-d496d50e660e", "obj6")
                );
            return sheet;
        }
        private QlikSheet Yield()
        {
            var sheet = new QlikSheet("17be2d8e-0112-4bda-86a1-f35136c40213", "Yield");
            sheet.addChilds(getMasterItems(YIELD, "1"));
            sheet.addChilds(getMasterItems(YIELDVSINDUSTRY, "2"));
            sheet.addChilds(getMasterFilters());
            sheet.addChilds(
                new QlikVisualization("180e48ca-e1b6-406a-a8c9-9740ae4ad55a", "obj3"),
                new QlikVisualization("cca42ddb-3528-41ab-af7b-367a0326fb70", "obj4"),
                new QlikVisualization("66b3ca37-a069-47d3-9a25-a514ebd5eef0", "obj5"),
                new QlikVisualization("3f6b07ae-5188-431e-9fbe-bd01494f4cad", "obj6")
                );
            return sheet;
        }

        private QlikSheet Revenue()
        {
            var sheet = new QlikSheet("ad0424c4-8c34-4de6-b512-e5e29f489034", "Revenue");

            sheet.addChilds(getMasterItems(REVENUESHARE, "1"));
            sheet.addChilds(getMasterItems(REVENUE, "2"));
            sheet.addChilds(getMasterItems(PAX, "3"));
            sheet.addChilds(getMasterItems(PASSENGER, "4"));
            sheet.addChilds(getMasterItems(YIELD, "5"));
            sheet.addChilds(getMasterItems(YIELDVSINDUSTRY, "6"));
            sheet.addChilds(getMasterFilters());


            sheet.addChilds(

                new QlikVisualization("unPkzL", "obj7"),
                new QlikVisualization("pRbFy", "obj8"),
                new QlikVisualization("rPmL", "obj9")
                );
            return sheet;
        }

       

        private QlikSheet routepassenger()
        {
            var sheet = new QlikSheet("2fd57181-f0ed-47a4-b09b-abfbeae212d4", "routepassenger");
            sheet.addChilds(getMasterItems(REVENUESHARE, "1"));
            sheet.addChilds(getMasterItems(REVENUE, "2"));
            sheet.addChilds(getMasterItems(PAX, "3"));
            sheet.addChilds(getMasterItems(PASSENGER, "4"));
            sheet.addChilds(getMasterItems(YIELD, "5"));
            sheet.addChilds(getMasterItems(YIELDVSINDUSTRY, "6"));
            sheet.addChilds(getMasterFilters());

            sheet.addChilds(

                new QlikVisualization("XXamPj", "obj7"),
                new QlikVisualization("SFAeyh", "obj8"),
                new QlikVisualization("beETN", "obj9")
                );
            return sheet;
        }

        private QlikSheet agentrevenue()
        {
            var sheet = new QlikSheet("55f41b5f-ab44-4a82-8a6a-23674036beaa", "agentrevenue");
            sheet.addChilds(getMasterItems(REVENUESHARE, "1"));
            sheet.addChilds(getMasterItems(REVENUE, "2"));
            sheet.addChilds(getMasterItems(PAX, "3"));
            sheet.addChilds(getMasterItems(PASSENGER, "4"));
            sheet.addChilds(getMasterItems(YIELD, "5"));
            sheet.addChilds(getMasterItems(YIELDVSINDUSTRY, "6"));
            sheet.addChilds(getMasterFilters());

            sheet.addChilds(

                new QlikVisualization("PZAvt", "obj7"),
                new QlikVisualization("pMpJXxt", "obj8"),
                new QlikVisualization("LmeqE", "obj9")
                );
            return sheet;
        }
        private QlikSheet agentrpassenger()
        {
            var sheet = new QlikSheet("92301427-4e77-46a4-ad76-9ca1fdcd53e9", "agentrpassenger");

            sheet.addChilds(getMasterItems(REVENUESHARE, "1"));
            sheet.addChilds(getMasterItems(REVENUE, "2"));
            sheet.addChilds(getMasterItems(PAX, "3"));
            sheet.addChilds(getMasterItems(PASSENGER, "4"));
            sheet.addChilds(getMasterItems(YIELD, "5"));
            sheet.addChilds(getMasterItems(YIELDVSINDUSTRY, "6"));
            sheet.addChilds(getMasterFilters());
            sheet.addChilds(

                new QlikVisualization("BPmPS", "obj7"),
                new QlikVisualization("PvCuEEq", "obj8"),
                new QlikVisualization("bPsyVs", "obj9")
                );
            return sheet;
        }

        private QlikSheet classAnalysis()
        {
            var sheet = new QlikSheet("5a13bc06-81e5-446d-be45-6b698fab6ebd", "classAnalysis");

            sheet.addChilds(getMasterItems(REVENUESHARE, "1"));
            sheet.addChilds(getMasterItems(REVENUE, "2"));
            sheet.addChilds(getMasterItems(PAX, "3"));
            sheet.addChilds(getMasterItems(PASSENGER, "4"));
            sheet.addChilds(getMasterItems(YIELD, "5"));
            sheet.addChilds(getMasterItems(YIELDVSINDUSTRY, "6"));
            sheet.addChilds(getMasterFilters());

            sheet.addChilds(

                new QlikVisualization("cJsQBV", "obj7"),
                new QlikVisualization("ggHZ", "obj8"),
                new QlikVisualization("PJPp", "obj9"),
                new QlikVisualization("UxrhjP", "obj10")
                );
            return sheet;
        }

        private QlikSheet performance()
        {
            var sheet = new QlikSheet("50b10d33-dcd6-4661-baed-9c0c80b09033", "performance");

            sheet.addChilds(getMasterItems(REVENUESHARE, "1"));
            sheet.addChilds(getMasterItems(REVENUE, "2"));
            sheet.addChilds(getMasterItems(PAX, "3"));
            sheet.addChilds(getMasterItems(PASSENGER, "4"));
            sheet.addChilds(getMasterItems(YIELD, "5"));
            sheet.addChilds(getMasterItems(YIELDVSINDUSTRY, "6"));
            sheet.addChilds(getMasterFilters());

            sheet.addChilds(

                new QlikVisualization("rpbnTBd", "obj7"),
                new QlikVisualization("aNqJG", "obj8")
                );
            return sheet;
        }

        private QlikSheet reporting()
        {
            var sheet = new QlikSheet("50b10d33-dcd6-4661-baed-9c0c80b09033", "reporting");

            sheet.addChilds(getMasterItems(REVENUESHARE, "1"));
            sheet.addChilds(getMasterItems(REVENUE, "2"));
            sheet.addChilds(getMasterItems(PAX, "3"));
            sheet.addChilds(getMasterItems(PASSENGER, "4"));
            sheet.addChilds(getMasterItems(YIELD, "5"));
            sheet.addChilds(getMasterItems(YIELDVSINDUSTRY, "6"));
            sheet.addChilds(getMasterFilters());

            sheet.addChilds(

                new QlikVisualization("muDgZnS", "obj7")
                );
            return sheet;
        }

    }
}

