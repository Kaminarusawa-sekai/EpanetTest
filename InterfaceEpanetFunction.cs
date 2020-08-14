using System;
using System.Collections.Generic;
using System.Text;

namespace EpanetTest
{

    interface InterfaceEpanetFunction
    {

        internal delegate void Feedback(params char[] arr);
        public void enEpanet(char filename1, char filename2, char filename3,  Feedback feedback);
        public Boolean enEpanet(char filename1, char filename2, char filename3);

        public Boolean enOpen(string filename1, string filename2, string filename3);

        public Boolean enClose();

        public int enGetNodeIndex(string id);

        public string enGetNodeId(int index);

        public int enGetNodeType(int index);

        public float enGetNodeValue(int index, int paramcode);

        public int enGetLinkIndex(string id);

        public string enGetLinkId(int index);

        public int enGetLinkType(int index);

        public int[] enGetLinkNodes(int index);

        public float enGetLinkValue(int index, int paramcode);

        public string enGetPatternId(int index);

        public int enGetPatternIndex(string id);

        public int enGetPatternLen(int index);

        public float enGetPatternValue(int index, int period);

        public float[] enGetControl(int index);

        public int enGetCount(int countcode);

        public int enGetFlowUnits();

        public long enGetTimeParam(int paramcode);


        public int enGetQualiType(int qualcode);

        public float enGetOption(int optioncode);

        public Boolean enSetControl(int cindex, int ctype, int lindex, float setting, int nindex, float level);

        public Boolean enSetNodeValue(int index, int paramcode, float value);

        public Boolean enSetLinkValue(int index, int paramcode, float value);

        public Boolean enSetPattern(int index, float[] factors, int nfactors);

        public Boolean enSetPatternValue(int index, int period, float value);

        public Boolean enSetQualType(int qualcode, string chemname, string chemunits, string tracenode);

        public Boolean enSetTimeParam(int paramcode, long timevalue);

        public Boolean enSetOption(int optioncode, float value);

        public Boolean enSaveHydFile(string filename);

        public Boolean enUseHydFile(string filename);

        public Boolean enSolveH();

        public Boolean enOpenH();

        public Boolean enInitH(Boolean saveflag);

        public Boolean enRunH();

        public Boolean enNextH();

        public Boolean enCloseH();

        public Boolean enSolveQ();

        public Boolean enOpenQ();

        public Boolean enInitQ(Boolean saveflag);

        public Boolean enRunQ();

        public Boolean enNextQ();

        public Boolean enStepQ();

        public Boolean enCloseQ();

        public Boolean enSaveH();

        public Boolean enSaveinpfile(string filename);

        public Boolean enReport();

        public Boolean enReSetReport();

        public Boolean enSetReport(string command);

        public Boolean enSetStatusReport(int statuslevel);

        public int enGetError(int getError);

    }
}
