using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using ZomboidBackupManager;
using static ZomboidBackupManager.Configuration;

namespace ZomboidBackupManager
{
    public enum SeparatorType
    {
        None,
        WhiteSpace,
        Light,
        Default,
        Moderat,
        Full
    }

    public enum LabelFramePart
    {
        FrameFill,
        FrameTop,
        FrameTopL,
        FrameTopR,
        FrameBase,
        FrameBaseL,
        FrameBaseR,
        FrameSide
    }

    public class SymbolLibrary
    {
        private Dictionary<SeparatorType, char> sepDict = new Dictionary<SeparatorType, char>();
        private Dictionary<char, SeparatorType> dictSep = new Dictionary<char, SeparatorType>();
        private Dictionary<LabelFramePart, char> frameDict = new Dictionary<LabelFramePart, char>();
        private List<LabelFramePart> frameTopParts = [LabelFramePart.FrameTopL, LabelFramePart.FrameTop, LabelFramePart.FrameTopR];
        private List<LabelFramePart> frameBaseParts = [LabelFramePart.FrameBaseL, LabelFramePart.FrameBase, LabelFramePart.FrameBaseR];
        private List<LabelFramePart> frameMidParts = [LabelFramePart.FrameSide, LabelFramePart.FrameFill, LabelFramePart.FrameSide];

        private char WS_Replacer = '*';
        private char Separator_WS = ' ';
        private char Separator_Light = '-';
        private char Separator_Default = '=';
        private char Separator_Moderat = '░';
        private char Separator_Full = '█';

        private char frameFill = 'x';
        private char frameSide = '║';
        private char frameTop = '═';
        private char frameTopL = '╔';
        private char frameTopR = '╗';
        private char frameBase = '═';
        private char frameBaseL = '╚';
        private char frameBaseR = '╝';


        public SymbolLibrary()
        {
            sepDict.Add(SeparatorType.WhiteSpace, Separator_WS);
            sepDict.Add(SeparatorType.Light, Separator_Light);
            sepDict.Add(SeparatorType.Default, Separator_Default);
            sepDict.Add(SeparatorType.Moderat, Separator_Moderat);
            sepDict.Add(SeparatorType.Full, Separator_Full);

            dictSep.Add(Separator_WS, SeparatorType.WhiteSpace);
            dictSep.Add(Separator_Light, SeparatorType.Light);
            dictSep.Add(Separator_Default, SeparatorType.Default);
            dictSep.Add(Separator_Moderat, SeparatorType.Moderat);
            dictSep.Add(Separator_Full, SeparatorType.Full);

            frameDict.Add(LabelFramePart.FrameFill, frameFill);
            frameDict.Add(LabelFramePart.FrameTop, frameTop);
            frameDict.Add(LabelFramePart.FrameTopL, frameTopL);
            frameDict.Add(LabelFramePart.FrameTopR, frameTopR);
            frameDict.Add(LabelFramePart.FrameBase, frameBase);
            frameDict.Add(LabelFramePart.FrameBaseL, frameBaseL);
            frameDict.Add(LabelFramePart.FrameBaseR, frameBaseR);
            frameDict.Add(LabelFramePart.FrameSide, frameSide);
        }

        public SeparatorType GetSeparatorType(char symbol = ' ')
        {
            return dictSep[symbol];
        }

        public char GetSeparator(SeparatorType type = SeparatorType.Default)
        {
            return sepDict[type];
        }

        public char GetFramePart(LabelFramePart part)
        {
            return frameDict[part];
        }

        public string GetFrameTop(int width, bool numeration = false, int num = 0)
        {
            string output = string.Empty;
            int adjustedWidth = width - 2;
            if (numeration)
            {
                adjustedWidth -= StaticLogFunctions.GetNumStringLength();
                output = StaticLogFunctions.GetAssembledNumString(num) + GetFramePart(frameTopParts[0]).ToString() + new string(GetFramePart(frameTopParts[1]), adjustedWidth) + GetFramePart(frameTopParts[2]).ToString();
            }
            else
            {
                output = GetFramePart(frameTopParts[0]).ToString() + new string(GetFramePart(frameTopParts[1]), adjustedWidth) + GetFramePart(frameTopParts[2]).ToString();
            }
            return output;
        }

        public string GetFrameBase(int width, bool numeration = false, int num = 0)
        {
            string output = string.Empty;
            int adjustedWidth = width - 2;
            if (numeration)
            {
                adjustedWidth -= StaticLogFunctions.GetNumStringLength();
                output = StaticLogFunctions.GetAssembledNumString(num) + GetFramePart(frameBaseParts[0]).ToString() + new string(GetFramePart(frameBaseParts[1]), adjustedWidth) + GetFramePart(frameBaseParts[2]).ToString();
            }
            else
            {
                output = GetFramePart(frameBaseParts[0]).ToString() + new string(GetFramePart(frameBaseParts[1]), adjustedWidth) + GetFramePart(frameBaseParts[2]).ToString();
            }
            return output;
        }

        public char GetWSReplacer()
        {
            return WS_Replacer;
        }
    }

    public class LogSize
    {
        private int width;
        private int height;
        private int widthOffset = 0;
        private int heightOffset = 0;

        public int Width { get; }
        public int Height { get; }
        public int WidthOffset { get; set; }
        public int HeightOffset { get; set; }

        public LogSize(ListBox log, float fontSize, int offsetX = 0, int offsetY = 0)
        {
            width = GetVisibleCharCountMonospace(log, fontSize, true);
            height = GetVisibleCharCountMonospace(log, fontSize, false);
            widthOffset = offsetX;
            heightOffset = offsetY;

            PrintDebug($"[LogSize] - [LogSize Created] - [Measured Size = {width} x {height}] - [offsetX = {offsetX}] - [offsetY = {offsetY}]");
        }

        public Size GetRawLogSize()
        {
            return new Size(width, height);
        }

        public Size GetLogSize()
        {
            return new Size(width - widthOffset, height - heightOffset);
        }

        public int GetLogWidth()
        {
            return width - widthOffset;
        }

        public int GetLogHeight()
        {
            return height - heightOffset;
        }

        private static int GetVisibleCharCountMonospace(ListBox listBox, float fontSize, bool bHorizontal = true)
        {
            Size measuredSize = TextRenderer.MeasureText("X", FontLoader.GetMonoFont(fontSize), new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);

            int charWidth = measuredSize.Width;
            int charHeight = measuredSize.Height;

            if (charWidth == 0 || charHeight == 0) return 0;

            int visibleWidth = listBox.ClientSize.Width;
            int visibleHeight = listBox.ClientSize.Height;

            if (bHorizontal)
            {
                return visibleWidth / charWidth;
            }
            else
            {
                return visibleHeight / charHeight;
            }
        }
    }

    public class FontData
    {
        public bool IsBolt { get; set; }

        public System.Drawing.Font Type { get; set; }
        public float Size { get; set; }

        public FontData(float size, bool bBolt = false)
        {
            Size = size;
            IsBolt = bBolt;
            Type = FontLoader.GetMonoFont(Size, IsBolt);
        }

        public void ChangeSize(float newSize)
        {
            float oldSize = Size;
            Size = newSize;
            Type = FontLoader.GetMonoFont(Size, IsBolt);
            PrintDebug($"[FontData] - [Changed FontData Size] - [From = {oldSize} To = {Size}]");
        }

        public void SwitchStyle()
        {
            IsBolt = !IsBolt;
            Type = FontLoader.GetMonoFont(Size, IsBolt);
        }
    }

    public class LogData
    {
        private ListBox logRef;
        private FontData font;
        private LogSize size;
        private bool numeration;
        private int maxLines;

        public ListBox LogRef { get { return logRef; } }
        public FontData FontStyle { get { return font; } set { font = value; } }
        public LogSize LogSize { get { return size; } }
        public bool Numeration { get { return numeration; } set { numeration = value; } }
        public int MaxLines { get { return maxLines; } set { maxLines = value; } }

        public LogData(ListBox listBox, bool num = true, float fontSize = 11f, int numMax = 999, bool bolt = false, int offsetX = 4, int offsetY = 0)
        {
            logRef = listBox;
            font = new FontData(fontSize, bolt);
            size = new LogSize(logRef, fontSize, offsetX, offsetY);
            numeration = num;
            maxLines = numMax;
            logRef.Font = font.Type;
        }

        public LogData(LogData logData)
        {
            //MessageBox.Show($"TEST = {logData}");
            logRef = logData.LogRef;
            font = new FontData(logData.FontStyle.Size, logData.FontStyle.IsBolt);
            size = new LogSize(logData.LogRef, logData.FontStyle.Size, logData.LogSize.WidthOffset, logData.LogSize.HeightOffset);
            numeration = logData.Numeration;
            maxLines = logData.MaxLines;
            logRef.Font = font.Type;
        }

        public void ToggleLogFontStyle()
        {
            font.SwitchStyle();
            logRef.Font = font.Type;
        }

        public void ChangeLogFontSize(float newSize = 11f)
        {
            font.ChangeSize(newSize);
            logRef.Font = font.Type;
        }

        public int GetLogItemCount()
        {
            return LogRef.Items.Count;
        }

        public Size GetLogSize()
        {
            return LogSize.GetLogSize();
        }

        public List<string> GetLogText()
        {
            string[] str = new string[GetLogItemCount()];
            LogRef.Items.CopyTo(str, 0);
            return str.ToList();
        }

        public void ClearLog()
        {
            logRef.Items.Clear();
        }
    }

    public class StatusLogWriter
    {
        public event EventHandler<Status>? OnStatusChanged;
        public event EventHandler<int>? OnScrollingDone;

        private LogData logData;
        private Status currentStatus;
        private Status lastStatus;

        private SymbolLibrary symbolLib;

        private int currentLogItemSelection = 0;

        public StatusLogWriter(ListBox listBox, bool numeration = false, float size = 11f, int numMax = 999, int offsetX = 4, int offsetY = 0)
        {
            symbolLib = new SymbolLibrary();

            logData = new LogData(listBox, numeration, size, numMax, false, offsetX, offsetY);

            OnStatusChanged += StatusChanged;
            OnScrollingDone += OnScrolling_Done;

            ChangeCurrentStatus(Status.INIT);

            StatusLogWriter_Ready();
        }

        public async void OnScrolling_Done(object? sender, int val)
        {
            await Task.Delay(250);
            currentLogItemSelection = val;
        }

        public int GetLogItemLimit()
        {
            return logData.MaxLines;
        }

        public void ClearStatusLog()
        {
            logData.ClearLog();
        }

        public void SetNumeration(bool bSet)
        {
            logData.Numeration = bSet;
        }

        public async Task WriteLabelToLog(string text, string value = "", string textValueSeparator = " & ")
        {
            int i = logData.GetLogItemCount();
            int width = logData.GetLogSize().Width;
            string input = $"[ {text}.{textValueSeparator}.{value} ]";
            string[] label = CreateSimpleLabel(input, width, logData.Numeration, i);
            await WriteContentToLog(label);
            await Task.Delay(100);
        }

        public async void WriteDualLabelToLog(string text, string value = "", SeparatorType sepTypeA = SeparatorType.Light)
        {
            int i = logData.GetLogItemCount();
            int width = logData.GetLogSize().Width;
            string[] label = CreateDualLabel(text, value, width, logData.Numeration, i);
            await WriteContentToLog(label);
        }

        public void ChangeFontSize(float newSize = 11f, bool bBolt = false)
        {
            logData.ChangeLogFontSize(newSize);
            logData = new LogData(logData);
            if (bBolt) { logData.ToggleLogFontStyle(); }
            logData.ClearLog();
        }

        public async void WriteModularLabelToLog(List<string> values, int sepEvery = 2, SeparatorType sepTypeA = SeparatorType.Light, SeparatorType sepTypeB = SeparatorType.Default)
        {
            if (currentStatus != Status.READY)
            {
                return;
            }
            ChangeCurrentStatus(Status.BUSY);
            string[] content = CreateModularLabel(values, logData.GetLogSize().Width, logData.Numeration, logData.GetLogItemCount(), sepTypeA, sepEvery, sepTypeB);
            await WriteContentToLog(content);
            await Task.Delay(100);
            ChangeCurrentStatus(Status.DONE);
        }

        private async Task<bool> WriteContentToLog(string[] lines, bool bAutoScroll = true)
        {
            await Task.Delay(250);
            string[] output = lines;
            ListBox log = logData.LogRef;
            int linesMax = logData.MaxLines;
            int linesCount = lines.Length;
            int itemCount = logData.GetLogItemCount();
            if (linesCount <= 0)
            {
                return false;
            }
            if (linesCount + itemCount >= linesMax)
            {
                logData.ClearLog();
                itemCount = 0;
            }
            if (output != null && output.Length > 0)
            {
                log.Items.AddRange(output);
                if (bAutoScroll)
                {
                    log.SelectionMode = SelectionMode.One;
                    log.SetSelected(logData.GetLogItemCount() - 1, true);     // To force the log box to automaticly jump to the last entry (Unnecessary - just for qol...)
                    currentLogItemSelection = log.SelectedIndex;    // To clear the visual selection within the status log box (Unnecessary - just looks better...)
                    await Task.Delay(200);
                    return true;
                }
            }
            return false;
        }

        private string CreateSeparatorLine(int width, SeparatorType type = SeparatorType.Default, bool numeration = false, int num = 0, bool bAddSides = true)
        {
            if (numeration)
            {
                int adjWidth = width - StaticLogFunctions.GetNumStringLength();
                if (bAddSides)
                {
                    return StaticLogFunctions.GetAssembledNumString(num) + symbolLib.GetFramePart(LabelFramePart.FrameSide).ToString() + new string(symbolLib.GetSeparator(type), adjWidth - 2) + symbolLib.GetFramePart(LabelFramePart.FrameSide).ToString();
                }
                else
                {
                    return StaticLogFunctions.GetAssembledNumString(num) + new string(symbolLib.GetSeparator(type), adjWidth);
                }
            }
            else
            {
                if (bAddSides)
                {
                    return symbolLib.GetFramePart(LabelFramePart.FrameSide).ToString() + new string(symbolLib.GetSeparator(type), width - 2) + symbolLib.GetFramePart(LabelFramePart.FrameSide).ToString();
                }
                else
                {
                    return new string(symbolLib.GetSeparator(type), width);
                }
            }
        }

        private string[] CreateEmptyLines(int amount = 1, int width = 0, bool numeration = false, int num = 0)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < amount; i++)
            {
                output.Add(CreateEmptyLine(width, numeration, num + i));
            }
            return output.ToArray();
        }

        private string CreateEmptyLine(int width, bool numeration = false, int num = 0)
        {
            if (numeration)
            {
                int adjWidth = width - StaticLogFunctions.GetNumStringLength();
                return StaticLogFunctions.GetAssembledNumString(num) + new string(symbolLib.GetSeparator(SeparatorType.WhiteSpace), adjWidth);
            }
            else
            {
                return new string(symbolLib.GetSeparator(SeparatorType.WhiteSpace), width);
            }
        }

        public async Task WriteEmptyLinesToLog(int amount = 1)
        {
            int idx = logData.GetLogItemCount();
            bool bNum = logData.Numeration;
            int width = logData.GetLogSize().Width;
            List<string> output = new List<string>();
            for (int i = 0; i < amount; i++)
            {
                string line = CreateEmptyLine(width, bNum, idx + i);
                output.Add(line);
            }
            await WriteContentToLog(output.ToArray());
        }

        public void ScrollLog(int iA, int iB, bool bUp = true)
        {
            logData.LogRef.SelectionMode = SelectionMode.One;
            if (bUp)
            {
                ScrollLogUp(iB, iA);
            }
            else
            {
                ScrollLogDown(iB, iA);
            }
        }

        private void ScrollLogUp(int steps = 1, int loops = 1)
        {
            ListBox log = logData.LogRef;
            int sel = log.SelectedIndex;
            for (int i = 0; i < loops; i++)
            {

                sel -= steps;
                if (sel < 0) { sel = 0; }
                log.SetSelected(sel, true);
            }
            OnScrollingDone?.Invoke(this, sel);
        }

        private void ScrollLogDown(int steps = 1, int loops = 1)
        {
            ListBox log = logData.LogRef;
            int sel = log.SelectedIndex;
            for (int i = 0; i < loops; i++)
            {
                sel += steps;
                if (sel > GetLogItemLimit()) { sel = 999; }
                log.SetSelected(sel, true);
            }
            OnScrollingDone?.Invoke(this, sel);
        }

        public async void WriteLabelsToLog(int steps = 1, int loops = 1, int separated = 0)
        {
            for (int i = 0; i < loops; i++)
            {
                int num = i + 1;
                await WriteLabelToLog("Test Label No. ", num.ToString());
                Task.WaitAll();
                if (separated > 0)
                {
                    await WriteEmptyLinesToLog(separated);
                }
                await Task.Delay(100);
            }
        }

        public async void WriteStepsToLog(int steps = 1, int loops = 1)
        {
            for (int i = 0; i < loops; i++)
            {
                await WriteEmptyLinesToLog(steps);
                await Task.Delay(100);
            }
        }

        private async void AddEmptyLinesToScroll(int steps = 1, int loops = 1)
        {
            ListBox log = logData.LogRef;
            for (int i = 0; i < loops; i++)
            {
                string[] lines = new string[steps];
                lines = CreateEmptyLines(steps, logData.GetLogSize().Width, logData.Numeration, logData.GetLogItemCount());
                await WriteContentToLog(lines);
                await Task.Delay(500);
            }
        }

        private string[] CreateSimpleLabelFromScratch(string txt, int width, string sAddBefore = " [ ", string sAddAfter = " ] ", bool numeration = false, int num = 0, SeparatorType sepType = SeparatorType.Light)
        {
            string newText = sAddBefore + txt + sAddAfter;
            return CreateSimpleLabel(newText, width, numeration, num, sepType);
        }

        private string[] CreateSimpleLabel(string txt, int width, bool numeration = false, int num = 0, SeparatorType sepType = SeparatorType.Light)
        {
            string text = txt;
            string[] label = new string[3];
            label[0] = symbolLib.GetFrameTop(width, numeration, num);
            label[1] = StaticLogFunctions.CenterText(text, width, symbolLib.GetSeparator(sepType), symbolLib.GetFramePart(LabelFramePart.FrameSide), true, numeration, num + 1);
            label[2] = symbolLib.GetFrameBase(width, numeration, num + 2);
            return label;
        }

        private string[] CreateDualLabel(string txt, string val, int width, bool numeration = false, int num = 0, SeparatorType sepType = SeparatorType.Light)
        {
            string text = $"[ {txt} ]";
            string value = $"[ {val} ]";
            string[] label = new string[4];
            label[0] = symbolLib.GetFrameTop(width, numeration, num);
            label[1] = StaticLogFunctions.CenterText(text, width, symbolLib.GetSeparator(sepType), symbolLib.GetFramePart(LabelFramePart.FrameSide), true, numeration, num + 1);
            label[2] = StaticLogFunctions.CenterText(value, width, symbolLib.GetSeparator(sepType), symbolLib.GetFramePart(LabelFramePart.FrameSide), true, numeration, num + 2);
            label[3] = symbolLib.GetFrameBase(width, numeration, num + 3);
            return label;
        }

        private string[] CreateModularLabel(List<string> values, int width, bool numeration = false, int num = 0, SeparatorType sepTypeA = SeparatorType.Light, int sepEvery = 2, SeparatorType sepTypeB = SeparatorType.Default)
        {
            List<string> label = new List<string>();
            label.Add(symbolLib.GetFrameTop(width, numeration, num));
            int i = 1;
            foreach (string val in values)
            {
                label.Add(StaticLogFunctions.CenterText(val, width, symbolLib.GetSeparator(sepTypeA), symbolLib.GetFramePart(LabelFramePart.FrameSide), true, numeration, num + i));
                if (sepEvery > 0)
                {
                    if ((i + 1) % sepEvery == 0)
                    {
                        i++;
                        label.Add(CreateSeparatorLine(width, sepTypeB, numeration, num + i));
                    }
                }
                i++;
            }
            label.Add(symbolLib.GetFrameBase(width, numeration, num + i));
            return label.ToArray();
        }

        private List<string> GetLogContents()
        {
            return logData.GetLogText();
        }

        private async void WriteInitLabelToLog()
        {
            ChangeCurrentStatus(Status.BUSY);
            PrintDebug($"[WriteInitLabelToLog] - [INIT DONE] - [Log Width = {logData.LogSize.GetLogWidth()}]");
            logData.ClearLog();
            string[] output = CreateSimpleLabelFromScratch("INIT DONE!", logData.LogSize.GetLogWidth(), "[ ", " ]", logData.Numeration, logData.GetLogItemCount());
            await WriteContentToLog(output);
            ChangeCurrentStatus(Status.DONE);
        }

        private async void StatusLogWriter_Ready()
        {
            await Task.Delay(1500);
            ChangeCurrentStatus(Status.INITDONE);
        }

        private void ChangeCurrentStatus(Status s)
        {
            lastStatus = currentStatus;
            currentStatus = s;
            OnStatusChanged?.Invoke(this, s);
        }

        private void StatusChanged(object? sender, Status s)
        {
            PrintDebug($"[StatusLogWriter] - [StatusChanged] - [To = {s.ToString()}]");
            if (s == Status.INIT)
            {

            }
            else if (s == Status.INITDONE)
            {
                WriteInitLabelToLog();

            }
            else if (s == Status.READY)
            {

            }
            else if (s == Status.BUSY)
            {

            }
            else if (s == Status.DONE)
            {
                ListBox log = logData.LogRef;
                int count = logData.GetLogItemCount() - 1;
                log.SelectionMode = SelectionMode.One;
                log.SetSelected(count, true);
                log.SelectedItem = null;
                ChangeCurrentStatus(Status.READY);
            }
        }
    }

    public static class StaticLogFunctions
    {
        //======================================================================================================================================
        //------------------------------------------------------- [ Static Functions ] ---------------------------------------------------------
        //======================================================================================================================================

        public static string CenterText(string text, int totalLength, char fillChar = 'x', char sideChar = ' ', bool addSides = false, bool numeration = false, int num = 0)
        {
            if (text.Length >= totalLength)
            {
                PrintDebug($"[CenterText] - [OutputText] - [Expected Length = {totalLength}] - [Length = {text.Length}] - [Text = {text}]");
                return text.Substring(0, totalLength);
            }
            string txt = string.Empty;
            string leftTxt = string.Empty;
            string RightTxt = string.Empty;
            int numStrLength = GetNumStringLength();
            int paddingTotal = totalLength - text.Length;
            int padLeft = paddingTotal / 2;
            int padRight = paddingTotal - padLeft;
            if (numeration)
            {
                padLeft -= numStrLength / 2;
                padRight -= numStrLength / 2;
            }
            if (addSides)
            {
                leftTxt = new string(fillChar, padLeft - 1);
                RightTxt = new string(fillChar, padRight - 1);
                txt = sideChar.ToString() + leftTxt + text + RightTxt + sideChar.ToString();
            }
            else
            {
                leftTxt = new string(fillChar, padLeft);
                RightTxt = new string(fillChar, padRight);
                txt = leftTxt + text + RightTxt;
            }
            if (numeration)
            {
                txt = StaticLogFunctions.GetAssembledNumString(num) + txt;
            }
            PrintDebug($"[CenterText] - [OutputText] - [Expected Length = {totalLength}] - [Length = {txt.Length}] - [Text = {txt}]");
            PrintDebug($"[CenterText] - [OutputText] - [paddingTotal = {paddingTotal}] - [padLeft = {padLeft}] - [padRight = {padRight}] - [- numStrLength = {numStrLength}]");
            return txt;
        }

        public static string GetAssembledNumString(int num)
        {
            string numString = num.ToString();
            if (num < 10)
            {
                numString = "00" + numString;
            }
            else if (num < 100)
            {
                numString = "0" + numString;
            }

            return GetFullNumString(numString);
        }

        private static string GetFullNumString(string num = "XXX")
        {
            return $"[{num}] - ";
        }

        public static int GetNumStringLength()
        {
            return GetFullNumString().Length;
        }
    }
}
