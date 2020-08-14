using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EpanetTest
{
    class OriginalEpanetFunction : InterfaceEpanetFunction
    {
        private  int errorCode = 0;

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENclose();
        public Boolean enClose()
        {
            try
            {
                errorCode=ENclose();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
            
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int ENcloseH();
        public unsafe Boolean enCloseH()
        {
            try
            {
                errorCode = ENcloseH();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int ENcloseQ();

        public Boolean enCloseQ()
        {
            try
            {
                errorCode = ENcloseQ();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        public void enEpanet(char f1, char f2, char f3, InterfaceEpanetFunction.Feedback feedback)
        {
            throw new NotImplementedException();
        }
        /*------------------------------------------------------------------------
         **   Input:   inpFile = name of EPANET formatted input file
         **            rptFile = name of report file
         **            outFile = name of binary output file
         ** pviewprog = see note below
         **   Output:  none
         ** Returns: error code
         **   Purpose: runs a complete EPANET simulation
         **
         ** The pviewprog() argument is a pointer to a callback function
         **  that takes a character string (char*) as its only parameter.

        ** The function would reside in and be used by the calling
         **  program to display the progress messages that EPANET generates
         **  as it carries out its computations.If this feature is not
         ** needed then the argument should be NULL.
         **-------------------------------------------------------------------------
         */ 
        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENepanet(char f1,char f2,char f3);
        public Boolean enEpanet(char filename1, char filename2, char filename3)
        {
            try { 
                errorCode= ENepanet(filename1, filename2, filename3);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
            
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetcontrol(int index, int* ctype, int* lindex, float* setting, int* nindex, float* level);
        public unsafe float[] enGetControl(int index)
        {
            int ctype = 0;
            int lindex = 0;
            float setting=0;
            int nindex = 0;
            float level = 0;

            int* pctype = &ctype;
            int* plindex = &lindex;
            float* psetting = &setting;
            int* pnindex = &nindex;
            float* plevel = &level;

            try
            {
                errorCode=ENgetcontrol(index, pctype, plindex, psetting, pnindex, plevel);
                float[] result = { (float)ctype, (float)lindex, setting, (float)nindex, level };
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return result;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetcount(int countcode,int* count);
        public unsafe int enGetCount(int countcode)
        {
            int count = 0;
            int* p = &count;
            try
            {
                errorCode = ENgetcount(countcode, p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return count;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgeterror(int errcode, char* errmasg, int nchar);
        public unsafe int enGetError(int errorCode)
        {
            int nchar = 80;
            char temp = ' ';
            char* errmsg = &temp;
            try
            {
                errorCode = ENgeterror(errorCode, errmsg, nchar);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return errorCode;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetflowunits(int* unitscode);
        public unsafe int enGetFlowUnits()
        {
            int unitscode = 0;
            int* p = &unitscode;
            try
            {
                errorCode = ENgetflowunits(p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return unitscode;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }
        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int ENgetlinkid( int index,char* id);
        public unsafe string enGetLinkId(int index)
        {
            char temp = 'a';
            char* p = &temp;
            try
            {
                
                errorCode = ENgetlinkid(index,p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return new string(p);
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int ENgetlinkindex(char[] id,int* index);
        public unsafe int enGetLinkIndex(string id)
        {
            int index = 0;
            int* p = &index;
            try
            {
                errorCode = ENgetlinkindex(id.ToCharArray(), p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return index;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetlinknodes(int index, int* fromnode, int* tonode);
        public unsafe int[] enGetLinkNodes(int index)
        {
            int fromnode = 0;
            int tonode = 0;

            int* pf = &fromnode;
            int* pt = &tonode;
            try
            {
                errorCode = ENgetlinknodes(index, pf, pt);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                int[] result = { fromnode, tonode };
                
                return result;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetlinktype(int index, int* typecode);
        public unsafe int enGetLinkType(int index)
        {
            int typecode = 0;
            int* p = &typecode;
            try{
                errorCode = ENgetlinktype(index,p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return typecode;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetlinkvalue(int index, int paramcode, float* value);
        public unsafe float enGetLinkValue(int index, int paramcode)
        {
            float value = 0;
            float* p = &value;
            try
            {
                errorCode = ENgetlinkvalue(index, paramcode,p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return value;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int ENgetnodeid(int index,  char* id);
        public unsafe string enGetNodeId(int index)
        {
            char temp = 'a';
            char* p=&temp;
            try
            {
                errorCode = ENgetnodeid(index, p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return new string(p);
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int ENgetnodeindex(char[] id, int* index);
        public unsafe int enGetNodeIndex(string id)
        {
            int index =  0 ;
            int* p = &index;
            try
            {
                errorCode = ENgetnodeindex(id.ToCharArray(), p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return index;
            }
            catch
            {
                throw new EpanetException(errorCode);
          
            }
            
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern int ENgetnodetype(int index, int* typecode);
        public unsafe int enGetNodeType(int index)
        {
            int typecode = 3;
            int* p = &typecode;
            try
            {
                errorCode = ENgetnodetype(index,p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return typecode;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private unsafe extern static int ENgetnodevalue(int index, int paramcode, float* value);
        public unsafe float enGetNodeValue(int index, int paramcode)
        {
            float value = 1;
            float* p = &value;
            try
            {
                errorCode = ENgetnodevalue(index, paramcode, p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return value;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetoption(int optioncode, float* value);
        public unsafe float enGetOption(int optioncode)
        {
            float value = 0;
            float* p = &value;
            try
            {
                errorCode = ENgetoption(optioncode, p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return value;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetpatternid(int index, char* id);
        public unsafe string enGetPatternId(int index)
        {
            char id = '0';
            char* p = &id;
            try
            {
                errorCode = ENgetpatternid(index,p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return new string(p);
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetpatternindex(char[] id, int* index);
        public unsafe int enGetPatternIndex(string id)
        {
            int index = 0;
            int* p = &index;
            try
            {
                errorCode = ENgetpatternindex(id.ToCharArray(), p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return index;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetpatternlen(int index, int* len);
        public unsafe int enGetPatternLen(int index)
        {
            int len = 0;
            int* p = &len;
            try
            {
                errorCode = ENgetpatternlen(index, p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return len;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetpatternvalue(int index, int period,float* value);
        public unsafe float enGetPatternValue(int index, int period)
        {
            float value = 0;
            float* p = &value;
            try
            {
                errorCode = ENgetpatternvalue(index, period, p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return value;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENgetqualitype(int* qualcode, int* tracecode);

        public unsafe int enGetQualiType(int tracenode)
        {
            int qualcode = 0;

            int* pq = &qualcode;
            int* pt = &tracenode;
            try
            {
                errorCode = ENgetqualitype(pq, pt);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return qualcode;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern int ENgettimeparam(int paramcode, long* timevalue);
        public unsafe long enGetTimeParam(int paramcode)
        {
            long timevalue = 0;
            long* p = &timevalue;
            try
            {
                errorCode = ENgettimeparam(paramcode, p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return timevalue;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENinitH(int saveflag);

        public Boolean enInitH(Boolean saveflag)
        {
            try
            {
                errorCode = ENinitH(Convert.ToInt32(saveflag));
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENinitQ(int saveflag);
        public Boolean enInitQ(Boolean saveflag)
        {
            try
            {
                errorCode = ENinitQ(Convert.ToInt32(saveflag));
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int ENnextH(long* timestep);

        public unsafe Boolean enNextH()
        {
            long timestep = 0;
            long* p = &timestep;
            try
            {
                errorCode = ENnextH(p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int ENnextQ(long* t);
        public unsafe Boolean enNextQ()
        {
            long timestep = 0;
            long* p = &timestep;
            try
            {
                errorCode = ENnextQ(p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int  ENopen(char[] f1, char[] f2, char[] f3);
        public  Boolean enOpen(string inputFilename, string reportFilename, string outputFilename)
        {
            try
            {
                errorCode=ENopen(inputFilename.ToCharArray(), reportFilename.ToCharArray(), outputFilename.ToCharArray());
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
                return false;
            }
            
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int ENopenH();
        public Boolean enOpenH()
        {
            try
            {
                errorCode = ENopenH();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENopenQ();
        public Boolean enOpenQ()
        {
            try
            {
                errorCode = ENopenQ();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENreport();

        public Boolean enReport()
        {
            try
            {
                errorCode = ENreport();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENresetreport();
        public Boolean enReSetReport()
        {
            try
            {
                errorCode = ENresetreport();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENrunH(long* currentTime);
        public unsafe Boolean enRunH()
        {
            long currentTime = 0;
            long* p = &currentTime;
            try
            {
                ENrunH(p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int ENrunQ(long* time);
        public unsafe Boolean enRunQ()
        {
            long time = 0;
            long* p = &time;
            try
            {
                errorCode = ENrunQ(p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsaveH();

        public Boolean enSaveH()
        {
            try
            {
                errorCode = ENsaveH();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsavehydfile(char[] filename);
        public Boolean enSaveHydFile(string filename)
        {
            try
            {
                errorCode = ENsavehydfile(filename.ToCharArray());
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int ENsaveinpfile(char[] filename);
        public Boolean enSaveinpfile(string filename)
        {
            try
            {
                errorCode = ENsaveinpfile(filename.ToCharArray());
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsetcontrol(int cindex, int ctype, int lindex, float setting, int nindex, float level);

        public Boolean enSetControl(int cindex, int ctype, int lindex, float setting, int nindex, float level)
        {
            try
            {
                errorCode = ENsetcontrol(cindex,ctype, lindex, setting, nindex, level);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
                return false;
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENsetlinkvalue(int index, int paramcode, float value);
        public Boolean enSetLinkValue(int index, int paramcode, float value)
        {
            try
            {
                errorCode = ENsetlinkvalue(index, paramcode, value);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENsetnodevalue(int index, int paramcode, float value);

        public Boolean enSetNodeValue(int index, int paramcode, float value)
        {
            try
            {
                errorCode = ENsetnodevalue(index, paramcode, value);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsetoption(int optioncode, float value);

        public Boolean enSetOption(int optioncode, float value)
        {
            try
            {
                errorCode = ENsetoption(optioncode, value);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
                return false;
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENsetpattern(int index, float[] factors, int nfactors);
        public Boolean enSetPattern(int index, float[] factors, int nfactors)
        {
            try
            {
                errorCode = ENsetpattern(index, factors, nfactors);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsetpatternvalue(int index, int period, float value);

        public Boolean enSetPatternValue(int index, int period, float value)
        {
            try
            {
                errorCode = ENsetpatternvalue(index, period, value);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsetqualtype(int qualcode, char[] chemname, char[] chemunits, char[] tracenode);
        public Boolean enSetQualType(int qualcode, string chemname, string chemunits, string tracenode)
        {
            try
            {
                errorCode = ENsetqualtype(qualcode, chemname.ToCharArray(), chemunits.ToCharArray(), tracenode.ToCharArray());
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsetreport(char[] command);
        public Boolean enSetReport(string command)
        {
            try
            {
                errorCode = ENsetreport(command.ToCharArray());
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsetstatusreport(int statuslevel);
        public Boolean enSetStatusReport(int statuslevel)
        {
            try
            {
                errorCode = ENsetstatusreport(statuslevel);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsettimeparam(int paramcode, long timevalue);
        public Boolean enSetTimeParam(int paramcode, long timevalue)
        {
            try
            {
                errorCode = ENsettimeparam(paramcode, timevalue);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int ENsolveH();
        public Boolean enSolveH()
        {
            try
            {
                errorCode = ENsolveH();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENsolveQ();
        public Boolean enSolveQ()
        {
            try
            {
                errorCode = ENsolveQ();
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static unsafe int ENstepQ(long* timeleft);
        public unsafe Boolean enStepQ()
        {
            long timeleft = 0;
            long* p = &timeleft;
            try
            {
                errorCode = ENstepQ(p);
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }

        [DllImport("EPANET2_x64.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ENusehydfile(char[] filename);

        public Boolean enUseHydFile(string filename)
        {
            try
            {
                errorCode = ENusehydfile(filename.ToCharArray());
                if (errorCode > 0)
                {
                    throw new EpanetException(errorCode);
                }
                return true;
            }
            catch
            {
                throw new EpanetException(errorCode);
            }
        }
    }
}
