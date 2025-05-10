using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Interop;
using ZstdSharp.Unsafe;
using Microsoft.VisualBasic.Logging;

namespace ZomboidBackupManager
{
    public enum LabelTemplates
    {
        None,
        Simple,
        LabelStart,
        LabelEnd,
        LabelSeparator,
        LabelHeadline,
        LabelName,
        LabelValue,
        LabelValues
    }

    public enum SeparatorType
    {
        None,
        WhiteSpace,
        Light,
        Default,
        Moderat,
        Full
    }

    public class SeparatorLibrary
    {
        private Dictionary<SeparatorType, char> dict = new Dictionary<SeparatorType, char>();

        private char WSReplacer = '*';
        private char WSSepChar = ' ';
        private char LightSepChar = '─';
        private char DefaultSepChar = '═';
        private char ModeratSepChar = '░';
        private char FullSepChar = '█';
        private char frameSide = '║';
        private char frameTop = '═';
        private char frameTopL = '╔';
        private char frameTopR = '╗';
        private char frameBase = '═';
        private char frameBaseL = '╚';
        private char frameBaseR = '╝';


        public SeparatorLibrary()
        {
            dict.Add(SeparatorType.WhiteSpace, WSSepChar);
            dict.Add(SeparatorType.Light, LightSepChar);
            dict.Add(SeparatorType.Default, DefaultSepChar);
            dict.Add(SeparatorType.Moderat, ModeratSepChar);
            dict.Add(SeparatorType.Full, FullSepChar);
        }

        public char GetSeparator(SeparatorType type = SeparatorType.Default)
        {
            return dict[type];
        }

        public char GetFrameSide()
        {
            return frameSide;
        }

        public char GetFrameTop(int part = 1)
        {
            if (part == 0) { return frameTopL; }
            if (part == 1) { return frameTop; }
            if (part == 2) { return frameTopR; }
            return frameTop;
        }

        public char GetFrameBase(int part = 1)
        {
            if (part == 0) { return frameBaseL; }
            if (part == 1) { return frameBase; }
            if (part == 2) { return frameBaseR; }
            return frameBase;
        }

        public char GetWSReplacer()
        {
            return WSReplacer;
        }
    }

    public class CursorPos
    {
        public int X;
        public int Y;

        public CursorPos(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class LogBuffer
    {
        public int Width;
        public int Height;

        public string[] Buffer;

        public CursorPos Cursor;

        public LogBuffer(int horizontal, int vertical)
        {
            Width = horizontal;
            Height = vertical;

            Buffer = CreateEmpty(Width, Height);
            PrintDebug($"Buffer.Length = {Buffer.Length}");
            Cursor = new CursorPos(0, 0);
        }

        public LogBuffer(LogBuffer log)
        {
            Width = log.Width;
            Height = log.Height;

            Buffer = CreateEmpty(Width, Height);
            PrintDebug($"Buffer.Length = {Buffer.Length}");
            Cursor = new CursorPos(0, 0);
        }

        public string[] CreateEmpty(int width, int height)
        {
            string[] output = new string[height];
            for (int i = 0; i < height; i++)
            {
                output[i] = new string(' ' , width);
            }
            return output;
        }

        public void ClearBuffer()
        {
            string[] emptyBuffer = CreateEmpty(Width, Height);
            Buffer = emptyBuffer;
        }

        public void InsertCursorPosInBuffer()
        {
            int cursorX = Cursor.X;
            int cursorY = Cursor.Y;
            List<string> current = Buffer.ToList();
            string line = current[cursorY];
            current.RemoveAt(cursorY);
            line = line.Remove(cursorX,1);
            line = line.Insert(cursorX, "█");
            current.Insert(cursorY, line);
            Buffer = current.ToArray();
        }

        private void ReplaceBufferValue(int x, int y, string value = " ")
        {
            if (y < 0) { y = 0; }
            if (y >= Height - 1) { y = Height - 1; }
            if (x < 0) { x = 0; }
            if (x >= Width - 1) { x = Width - 1; }
            List<string> current = Buffer.ToList();
            string line = current[y];
            current.RemoveAt(y);
            line = line.Remove(x, 1);
            line = line.Insert(x, value);
            current.Insert(y, line);
            Buffer = current.ToArray();
        }

        public int GetBufferHight()
        {
            return Buffer.Length;
        }

        public int GetBufferWidth()
        {
            return Buffer[0].Length;
        }

        public void SetCursorPos(int x, int y)
        {
            Cursor.X = x;
            Cursor.Y = y;
            //PrintDebug($"[StatusLogWriter.cs] - [LogBuffer] - [SetCursorPos] - [X = {Cursor.X}] - [Y = {Cursor.Y}]");
        }

        public async void DrawSquare(int x, int y, int length, int height, char c = '█')
        {
            SetCursorPos(x, y);
            await Task.Delay(200);
            DrawLine(2, height, c);
            await Task.Delay(100);
            DrawLine(1, length, c);
            await Task.Delay(100);
            DrawLine(0, height, c);
            await Task.Delay(100);
            DrawLine(3, length, c);
        }

        public void DrawLine(int dir = 1, int length = 5, char c = '█')
        {
            if (dir == 0)
            {
                DrawVerticalLine(length, true, c);
            }
            else if (dir == 1)
            {
                DrawHorizontalLine(length, false, c);
            }
            else if (dir == 2)
            {
                DrawVerticalLine(length, false, c);
            }
            else if (dir == 3)
            {
                DrawHorizontalLine(length, true, c);
            }
        }

        private void DrawVerticalLine(int height, bool bUp = true, char c = '█')
        {
            if (bUp)
            {
                for (int i = height; i > 0; i--)
                {
                    ReplaceBufferValue(Cursor.X, Cursor.Y, c.ToString());
                    int res = MoveCursorPos(0, 1);
                    if (res <= 0)
                    {
                        ReplaceBufferValue(Cursor.X, Cursor.Y, c.ToString());
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    ReplaceBufferValue(Cursor.X, Cursor.Y, c.ToString());
                    int res = MoveCursorPos(2, 1);
                    if (res >= Height - 1)
                    {
                        ReplaceBufferValue(Cursor.X, Cursor.Y, c.ToString());
                        return;
                    }
                }
            }
        }

        private void DrawHorizontalLine(int length, bool bLeft = false, char c = '█')
        {
            if (bLeft)
            {
                for (int i = length; i > 0; i--)
                {
                    ReplaceBufferValue(Cursor.X, Cursor.Y, c.ToString());
                    int res = MoveCursorPos(3, 1);
                    if (res <= 0)
                    {
                        ReplaceBufferValue(Cursor.X, Cursor.Y, c.ToString());
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    ReplaceBufferValue(Cursor.X, Cursor.Y, c.ToString());
                    int res = MoveCursorPos(1, 1);
                    if (res >= Width - 1)
                    {
                        ReplaceBufferValue(Cursor.X, Cursor.Y, c.ToString());
                        return;
                    }
                }
            }
        }

        public int MoveCursorPos(int dir = 1, int steps = 1)
        {
            //PrintDebug($"[StatusLogWriter.cs] - [LogBuffer] - [SetCursorPos] - [From] - [X = {Cursor.X}] - [Y = {Cursor.Y}]");
            if ( dir == 0)
            {
                return MoveCursorVertical(steps, true);
            }
            else if (dir == 1)
            {
                return MoveCursorHorizontal(steps, false);
            }
            else if (dir == 2)
            {
                return MoveCursorVertical(steps, false);
            }
            else if (dir == 3)
            {
                return MoveCursorHorizontal(steps, true);
            }
            return -1;
        }

        private int MoveCursorVertical(int steps = 1, bool bUp = true)
        {
            CursorPos lastPos = Cursor;
            if (bUp)
            {
                Cursor.Y -= steps;
                if (Cursor.Y < 0)
                {
                    Cursor.Y = 0;
                }
                return Cursor.Y;
            }
            else
            {
                Cursor.Y += steps;
                if (Cursor.Y >= Height - 1)
                {
                    Cursor.Y = lastPos.Y;
                }
                return Cursor.Y;
            }
        }

        private int MoveCursorHorizontal(int steps = 1, bool bLeft = true)
        {
            CursorPos lastPos = Cursor;
            if (bLeft)
            {
                Cursor.X -= steps;
                if (Cursor.X < 0)
                {
                    Cursor.X = 0;
                }
                return Cursor.X;
            }
            else
            {
                Cursor.X += steps;
                if (Cursor.X >= Width - 1)
                {
                    Cursor.X = lastPos.X;
                }
                return Cursor.X;
            }
        }
    }

    public class StatusLogWriter
    {
        private LogBuffer logBuffer;
        private LogBuffer lastBuffer;

        public event EventHandler<Status>? OnStatusChanged;

        private ListBox StatusLogListBox;
        private Status status;
        private Status lastStatus;

        // Text Format Setup
        private int maxWidth = 1;
        private int maxHeight = 1;

        // Log Structure Setup
        private bool lineNumeration = true;
        public bool LineNumeration { set { lineNumeration = value; } }
        private float fontSize = 11f;
        public float FontSize { set { fontSize = value; } }
        private int lineNumMax = 999;
        public int LineNumMax { get { return lineNumMax; } set { lineNumMax = value; } }
        private char WhiteSpaceReplaceChar = '*';
        private char WhiteSpaceSepChar = 'x';
        private char LightSepChar = '─';
        private char DefaultSepChar = '═';
        private char ModeratSepChar = '░';
        private char FullSepChar = '█';
        private char SideSepChar = '║';
        private char labelStartSep = '═';
        private char labelStartSepL = '╔';
        private char labelStartSepR = '╗';
        private char labelEndSep = '═';
        private char labelEndSepL = '╚';
        private char labelEndSepR = '╝';
        private readonly string labelPresetSimple = "[*<>*]";
        private readonly string labelPresetHeadline = "*[*<>*]*";
        private readonly string labelPresetName = "*(*<>*)*";
        private readonly string labelPresetValue = "*(*<>*)*";

        // Dictionaries
        private Dictionary<int, LabelTemplates> integerToTemplate;

        // Label Cache
        private Dictionary<string, List<LabelTemplates>> customLabels;

        private Dictionary<List<LabelTemplates>, string> labelsToHeadline;
        private Dictionary<List<LabelTemplates>, string> labelsToName;
        private Dictionary<List<LabelTemplates>, string> labelsToValue;
        private Dictionary<List<LabelTemplates>, List<string>> labelsToValues;
        private Dictionary<List<LabelTemplates>, SeparatorType> labelsToSepType;

        public StatusLogWriter(ListBox listBox, bool numeration = true, float size = 11f, int numMax = 999, char ws = ' ', char lSChar = '─', char bSChar = '═')
        {
            StatusLogListBox = listBox;
            status = Status.INIT;
            lastStatus = status;
            OnStatusChanged += StatusChanged;

            fontSize = size;
            lineNumeration = numeration;
            lineNumMax = numMax;
            WhiteSpaceSepChar = ws;
            LightSepChar = lSChar;
            DefaultSepChar = bSChar;

            StatusLogListBox.Font = FontLoader.LoadEmbeddedFont("ZomboidBackupManager.Fonts.UbuntuMono-Regular.ttf", size);

            integerToTemplate = new Dictionary<int, LabelTemplates>();
            customLabels = new Dictionary<string, List<LabelTemplates>>();
            labelsToHeadline = new Dictionary<List<LabelTemplates>, string>();
            labelsToName = new Dictionary<List<LabelTemplates>, string>();
            labelsToValue = new Dictionary<List<LabelTemplates>, string>();
            labelsToValues = new Dictionary<List<LabelTemplates>, List<string>>();
            labelsToSepType = new Dictionary<List<LabelTemplates>, SeparatorType>();

            logBuffer = GetVisibleCharCountMonospace(listBox);
            lastBuffer = logBuffer;

            maxWidth = logBuffer.Width;
            maxHeight = logBuffer.Height;

            PrintDebug($"[StatusLogWriter.cs] - [Constructor] - [maxWidth = {maxWidth}] - [maxHeight = {maxHeight}]");

            CreateDictionaries();

            CreateInitLabel();
            CreateDefaultLabels();

            StatusLogWriter_Ready();
        }

        private bool FlushLog()
        {
            string[] buffer = logBuffer.Buffer;
            if (buffer != null && buffer.Length > 0)
            {
                lastBuffer = logBuffer;
                logBuffer.ClearBuffer();
                StatusLogListBox.Items.Clear();
                StatusLogListBox.Items.AddRange(buffer);
                StatusLogListBox.SetSelected(StatusLogListBox.Items.Count - 1, true);   // To force the log box to automaticly jump to the last entry (Unnecessary - just for qol...)
                StatusLogListBox.SelectedItem = null;                                   // To clear the visual selection within the status log box (Unnecessary - just looks better...)
                return true;
            }
            return false;
        }

        public async void Test()
        {
            for(int i = 1; i < 26; i++)
            {
                await TestLoop(i);
                await Task.Delay(750);
            }
        }

        public async Task TestLoop(int iScroll)
        {
            logBuffer.DrawSquare(16, iScroll, 52, 12);
            await Task.Delay(250);
            FlushLog();
        }

        private void ChangeFontSize(ListBox log, float size = 11f)
        {
            

        }

        private async void ReloadLogContent()
        {
            await Task.Delay(250);

        }

        private void CreateDefaultLabels()
        {
            CreateDefaultLabels_ScanUnlisted();
            CreateDefaultLabels_ScanJsonData();
        }


        private void CreateDefaultLabels_ScanUnlisted()
        {
            CreateLabel_Scan();
            CreateLabel_ScanDone();
            CreateLabel_ScanResult();
        }

        private void CreateDefaultLabels_ScanJsonData()
        {
            CreateLabel_ScanJson();
            CreateLabel_ScanJsonDone();
            CreateLabel_ScanJsonResult();
        }

        private void CreateDictionaries()
        {
            integerToTemplate.Add(0, LabelTemplates.None);
            integerToTemplate.Add(1, LabelTemplates.Simple);
            integerToTemplate.Add(2, LabelTemplates.LabelStart);
            integerToTemplate.Add(3, LabelTemplates.LabelEnd);
            integerToTemplate.Add(4, LabelTemplates.LabelSeparator);
            integerToTemplate.Add(5, LabelTemplates.LabelHeadline);
            integerToTemplate.Add(6, LabelTemplates.LabelName);
            integerToTemplate.Add(7, LabelTemplates.LabelValue);
            integerToTemplate.Add(8, LabelTemplates.LabelValues);
        }

        private async void StatusLogWriter_Ready()
        {
            await Task.Delay(1500);
            ChangeCurrentStatus(Status.READY);
        }

        private void ChangeCurrentStatus(Status s)
        {
            lastStatus = status;
            status = s;
            OnStatusChanged?.Invoke(this, s);
        }

        private void StatusChanged(object? sender, Status s)
        {
            PrintDebug($"[StatusLogWriter.cs] - [OnStatusChanged] - [To = {s.ToString()}]");
            if (s == Status.INIT)
            {

            }
            else if (s == Status.READY)
            {
                if (lastStatus == Status.INIT)
                {
                    WriteInitLabelToLog();
                }
            }
            else if (s == Status.BUSY)
            {

            }
            else if (s == Status.DONE)
            {
                ChangeCurrentStatus(Status.DONE);
            }
        }

        private string ReplaceWithNumeration(string line, int num)
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

            string fullNumString = GetFullNumString(numString);
            line = RemoveCharsForNumeration(line);
            return fullNumString + line;
        }

        private string RemoveCharsForNumeration(string line)
        {
            char firstChar = line[0];
            int len = GetNumStringLength();
            if (line.Length >= len) { line = line.Remove(0, len + 1); }
            line = line.Insert(0, firstChar.ToString());
            return line;
        }

        private void WriteLinesToLog(string[] lines)
        {
            string[] output;
            if (lineNumeration)
            {
                int idx = StatusLogListBox.Items.Count;
                if ((idx + lines.Length) > lineNumMax)
                {
                    StatusLogListBox.Items.Clear();
                    idx = 1;
                }
                List<string> temp = new List<string>();
                foreach (string line in lines)
                {
                    string numLine = ReplaceWithNumeration(line, idx);
                    temp.Add(numLine);
                    idx++;
                }
                output = temp.ToArray();
            }
            else
            {
                output = lines;
            }
            if (output != null && output.Length > 0)
            {
                StatusLogListBox.Items.AddRange(output);
                StatusLogListBox.SelectionMode = SelectionMode.One;
                StatusLogListBox.SetSelected(StatusLogListBox.Items.Count - 1, true);   // To force the log box to automaticly jump to the last entry (Unnecessary - just for qol...)
                StatusLogListBox.SelectedItem = null;                                   // To clear the visual selection within the status log box (Unnecessary - just looks better...)
            }
        }

        public void WriteInitLabelToLog()
        {
            string[] output = TextLog_GetCustomLabel("Init");
            StatusLogListBox.Items.Clear();
            WriteLinesToLog(output);
        }

        public void WriteDefaultLabelToLog(string labelName, string? value = null, List<string>? values = null)
        {
            if (values == null)
            {
                values = new List<string>();
            }

            string[] output = TextLog_GetCustomLabel(labelName,value ,values);
            WriteLinesToLog(output);
        }

        public void WriteSingleSeparatorLineToLog(SeparatorType sep = SeparatorType.Default, bool addSides = true)
        {
            string[] output = new string[1];
            output[0] = GetSeparatorLine(sep, maxWidth, addSides, addSides);
            WriteLinesToLog(output);
        }

        public void WriteSingleLineToLog(string text, int sepLinesBefore = 0, int sepLinesAfter = 0, SeparatorType sep = SeparatorType.WhiteSpace, SeparatorType sepText = SeparatorType.Default, bool addSides = true)
        {
            string sepLine = GetSeparatorLine(sep, maxWidth, addSides, addSides);
            List<string> sepListBefore = new List<string>();
            List<string> sepListAfter = new List<string>();
            for (int i = 0; i < sepLinesBefore; i++)
            {
                sepListBefore.Add(sepLine);
            }
            for (int i = 0; i < sepLinesAfter; i++)
            {
                sepListAfter.Add(sepLine);
            }
            string str = GetCustomLabelTextLine(LabelTemplates.Simple, sepText, text, addSides);
            List<string> outputList = new List<string>();
            outputList.AddRange(sepListBefore);
            outputList.Add(str);
            outputList.AddRange(sepListAfter);
            WriteLinesToLog(outputList.ToArray());
        }

        private void CreateInitLabel()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("2563");
            bool result = CreateCustomLabel(list, "Init", "Initialized", "Welcome Human!");
            PrintDebug($"[StatusLogWriter.cs] - [CreateInitLabel] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_Scan()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("253");
            bool result = CreateCustomLabel(list, "Scan", "Starting Scan");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_Scan] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_ScanDone()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("2573");
            bool result = CreateCustomLabel(list, "ScanDone", "Scan Unlisted Done", "Unlisted folders found:");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_ScanDone] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_ScanResult()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("25843");
            bool result = CreateCustomLabel(list, "ScanUnlistedResult" , "Unlistet folder");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_ScanResult] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_ScanJson()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("253");
            bool result = CreateCustomLabel(list, "ScanJson", "Starting Scan");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_ScanJson] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_ScanJsonDone()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("2573");
            bool result = CreateCustomLabel(list, "ScanJsonDone", "Scan Json Done", "Broken json data files found:");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_ScanJsonDone] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_ScanJsonResult()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("25843");
            bool result = CreateCustomLabel(list, "ScanJsonResult", "Broken Json Data:");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_ScanJsonResult] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_AutoClean()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("253");
            bool result = CreateCustomLabel(list, "ScanJson", "Starting Scan");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_ScanJson] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_AutoCleanDone()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("2573");
            bool result = CreateCustomLabel(list, "ScanJsonDone", "Scan Json Done", "Broken json data files found:");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_ScanJsonDone] - [CreateCustomLabel Result] = [{result}]");
        }

        private void CreateLabel_AutoCleanResult()
        {
            List<LabelTemplates> list = CreateBasicPresetStructureList("25843");
            bool result = CreateCustomLabel(list, "ScanJsonResult", "Broken Json Data:");
            PrintDebug($"[StatusLogWriter.cs] - [CreateLabel_ScanJsonResult] - [CreateCustomLabel Result] = [{result}]");
        }

        private List<LabelTemplates> CreateBasicPresetStructureList(string numeratedStructureString)
        {
            char[] numeratedStructureArray = numeratedStructureString.ToCharArray();
            List<int> intList = new List<int>();
            if (numeratedStructureArray.Length <= 0)
            {
                return new List<LabelTemplates>();
            }
            foreach (char num in numeratedStructureArray)
            {
                if (char.IsDigit(num))
                {
                    intList.Add(int.Parse(num.ToString()));
                }
            }
            List<LabelTemplates> outputList = new List<LabelTemplates>();
            foreach (int val in intList)
            {
                outputList.Add(integerToTemplate[val]);
            }
            return outputList;        
        }

        private string[] TextLog_GetCustomLabel(string labelName, string? singleVal = null, List<string>? inputValues = null)
        {
            List<string> outputList = new List<string>();
            List<LabelTemplates> labelStructure = GetRawCustomLabelList(labelName);

            if (labelStructure.Count <= 0) { return outputList.ToArray(); }

            foreach (var line in labelStructure)
            {
                PrintDebug($"[StatusLogWriter.cs] - [TextLog_GetCustomLabel] = [line = {line}] = [inputValues.Count = {inputValues?.Count}]");
                string str = 0.ToString();
                if (line == LabelTemplates.LabelValue)
                {
                    if (string.IsNullOrWhiteSpace(singleVal))
                    {
                        singleVal = string.Empty;
                    }
                    str = GetCustomLabelValueLine(singleVal, SeparatorType.Light, true);
                    outputList.Add(str);
                }
                else if (line == LabelTemplates.LabelValues)
                {
                    if (inputValues != null && inputValues.Count > 0)
                    {
                        foreach (string value in inputValues)
                        {
                            str = GetCustomLabelValueLine(value, SeparatorType.Light, true);
                            outputList.Add(str);
                        }
                    }
                }
                else
                {
                    List<string>? temp = GetCustomLabelInput(labelStructure, line);
                    if (temp == null || temp.Count <= 0)
                    {
                        temp = [string.Empty];
                    }
                    PrintDebug($"[StatusLogWriter.cs] - [TextLog_GetCustomLabel] = [temp.Count = {temp.Count}]");
                    str = GetCustomPresetLine(line, temp?[0]);
                    outputList.Add(str);
                }
            }
            return outputList.ToArray();
        }

        private bool CreateCustomLabel(List<LabelTemplates> structureList, string labelName, string? labelHeadline = null, string? labelText = null, List<string>? labelValues = null, SeparatorType sepType = SeparatorType.Light)
        {
            bool result = false;
            if (structureList.Count <= 0) { return false; }
            result = customLabels.TryAdd(labelName, structureList);
            if (!result) { return result; }
            if (labelHeadline == null)
            {
                labelHeadline = string.Empty;
            }
            result = false;
            result = labelsToHeadline.TryAdd(customLabels[labelName], labelHeadline);
            if (!result) { return result; }
            if (labelText == null)
            {
                labelText = string.Empty;
            }
            result = false;
            result = labelsToName.TryAdd(customLabels[labelName], labelText);
            if (!result) { return result; }
            if (labelValues == null || labelValues.Count <= 0)
            {
                labelValues = [string.Empty];
            }
            result = false;
            result = labelsToValue.TryAdd(customLabels[labelName], labelValues[0]);
            if (!result) { return result; }
            result = false;
            result = labelsToValues.TryAdd(customLabels[labelName], labelValues);
            if (!result) { return result; }
            result = false;
            result = labelsToSepType.TryAdd(customLabels[labelName], sepType);
            return result;
        }


        private List<string> GetCustomLabelInput(List<LabelTemplates> list, LabelTemplates id)
        {
            List<string> outputList = new List<string>();

            PrintDebug($"[StatusLogWriter.cs] - [GetCustomLabelInput] = [list.Count = {list.Count}] - [id = {id}]");

            switch (id)
            {
                case LabelTemplates.None:
                    return outputList;
                case LabelTemplates.LabelHeadline:
                    outputList.Insert(0, labelsToHeadline[list]);
                    return outputList;
                case LabelTemplates.LabelName:
                    outputList.Insert(0, labelsToName[list]);
                    return outputList;
                case LabelTemplates.LabelValue:
                    outputList.Insert(0, labelsToValue[list]);
                    return outputList;
                case LabelTemplates.LabelValues:
                    outputList = labelsToValues[list];
                    return outputList;
                default:
                    return outputList;
            }
        }

        private List<LabelTemplates> GetRawCustomLabelList(string labelName)
        {
            return customLabels.GetValueOrDefault(labelName, new List<LabelTemplates>());
        }

        private string GetCustomPresetLine(LabelTemplates id, string? input = null, SeparatorType setupSepLine = SeparatorType.Light)
        {
            PrintDebug($"[StatusLogWriter.cs] - [GetCustomPresetLine] - [id = {id}] - [input = {input}]");

            switch (id)
            {
                case LabelTemplates.None:
                    return string.Empty;
                case LabelTemplates.LabelStart:
                    return GetCustomLabelStartEndLine(true);
                case LabelTemplates.LabelEnd:
                    return GetCustomLabelStartEndLine(false);
                case LabelTemplates.LabelSeparator:
                    return GetSeparatorLine(setupSepLine, maxWidth, true, true);
                case LabelTemplates.LabelHeadline:
                    return GetCustomLabelTextLine(id , SeparatorType.Light, input!);
                case LabelTemplates.LabelName:
                    return GetCustomLabelTextLine(id, SeparatorType.Light, input!);
                case LabelTemplates.LabelValue:
                    return GetCustomLabelValueLine(input , SeparatorType.Light);
                case LabelTemplates.LabelValues:
                    return GetCustomLabelValueLine(input, SeparatorType.Light);
                default:
                    return string.Empty;
            }
        }

        private string GetCustomLabelStartEndLine(bool bStart = true)
        {
            if (bStart)
            {
                return labelStartSepL + new string(labelStartSep, maxWidth - 2) + labelStartSepR;
            }
            else
            {
                return labelEndSepL + new string(labelEndSep, maxWidth - 2) + labelEndSepR;
            }
        }

        private string GetCustomLabelSeparatorLine(SeparatorType type)
        {
            string output = string.Empty;
            char c = GetLabelSymbolTypeChar(type);
            for (int i = 0; i < maxWidth; i++)
            {
                output.Append(c);
            }
            return output;
        }

        private string GetSeparatorLine(SeparatorType type, int width, bool addSideL = true, bool addSideR = true)
        {
            char c = GetLabelSymbolTypeChar(type);
            string output = new string(c, width);
            output = AddSideSeparators(output, addSideL, addSideR);
            return output;
        }

        private string AddSideSeparators(string str, bool addStart = true, bool addEnd = true)
        {
            if (addStart)
            {
                str = str.Remove(0, 1);
                str = SideSepChar.ToString() + str;
            }
            if (addEnd)
            {
                str = str.Remove(str.Length - 2, 1);
                str = str + SideSepChar.ToString();
            }
            return str;
        }

        /*
        private string CenterText(string text, int totalLength, char fillChar = '*')
        {
            if (text.Length >= totalLength)
            {
                return text.Substring(0, totalLength);
            }
            int paddingTotal = totalLength - text.Length;
            int padLeft = paddingTotal / 2;
            if (lineNumeration) { padLeft += GetNumStringLength() / 2; }
            int padRight = paddingTotal - padLeft;

            return new string(fillChar, padLeft) + text + new string(fillChar, padRight);
        }
        */

        private string GetCustomLabelTextLine(LabelTemplates lineTextType , SeparatorType sep , string labelInsertText = "", bool addSides = true)
        {
            string output = string.Empty;
            string preset = GetLabelLinePreset(lineTextType);
            if (!string.IsNullOrWhiteSpace(preset))
            {
                if (preset.Contains('<'))
                {
                    List<string> list = new List<string>();
                    string[] splitted = preset.Split('<', 3 , StringSplitOptions.None);
                    if (splitted.Length > 0)
                    {
                        foreach (string key in splitted)
                        {
                            list.Add(key);
                        }
                        list.Insert(1, labelInsertText);
                        string str = string.Empty;
                        foreach (string item in list)
                        {
                            str += item;
                        }
                        int idx = str.IndexOf('>');
                        str = str.Replace('>', ' ');
                        str = str.Remove(idx, 1);
                        output = CenterText(str, maxWidth, GetLabelSymbolTypeChar(sep), lineNumeration);
                        output = output.Replace(WhiteSpaceReplaceChar, ' ');
                        if (addSides) { output = AddSideSeparators(output, addSides, addSides); }
                    }
                }
            }
            return output;
        }

        private string GetCustomLabelValueLine(string? inputValue, SeparatorType sep, bool addSides = true)
        {
            string output = string.Empty;
            if (inputValue == null) { return output; }
            string preset = GetLabelLinePreset(LabelTemplates.LabelValue);
            if (!string.IsNullOrWhiteSpace(preset))
            {
                if (preset.Contains('<'))
                {
                    List<string> list = new List<string>();
                    string[] splitted = preset.Split('<', 3, StringSplitOptions.None);
                    if (splitted.Length > 0)
                    {
                        foreach (string key in splitted)
                        {
                            list.Add(key);
                        }
                        list.Insert(1, inputValue);
                        string str = string.Empty;
                        foreach (string item in list)
                        {
                            str += item;
                        }
                        int idx = str.IndexOf('>');
                        str = str.Replace('>', ' ');
                        str = str.Remove(idx, 1);
                        output = CenterText(str, maxWidth, GetLabelSymbolTypeChar(sep), lineNumeration);
                        output = output.Replace(WhiteSpaceReplaceChar, ' ');
                        if (addSides) { output = AddSideSeparators(output, addSides, addSides); }
                    }
                }
            }
            return output;
        }

        private string GetLabelLinePreset(LabelTemplates id)
        {
            switch (id)
            {
                case LabelTemplates.None:
                    return string.Empty;
                case LabelTemplates.Simple:
                    return labelPresetSimple;
                case LabelTemplates.LabelHeadline:
                    return labelPresetHeadline;
                case LabelTemplates.LabelName:
                    return labelPresetName;
                case LabelTemplates.LabelValue:
                    return labelPresetValue;
                case LabelTemplates.LabelValues:
                    return labelPresetValue;
                default:
                    return string.Empty;
            }
        }

        private char GetLabelSymbolTypeChar(SeparatorType type)
        {
            switch (type)
            {
                case SeparatorType.None:
                    return ' ';
                case SeparatorType.WhiteSpace:
                    return WhiteSpaceSepChar;
                case SeparatorType.Light:
                    return LightSepChar;
                case SeparatorType.Default:
                    return DefaultSepChar;
                case SeparatorType.Moderat:
                    return ModeratSepChar;
                case SeparatorType.Full:
                    return FullSepChar;
                default:
                    return ' ';
            }
        }

        public static LogBuffer GetVisibleCharCountMonospace(ListBox listBox)
        {
            Size measuredSize = TextRenderer.MeasureText("X", listBox.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
            LogBuffer logBuffer = new LogBuffer(measuredSize.Width, measuredSize.Height);
            int charWidth = logBuffer.Width;
            int charHeight = logBuffer.Height;

            if (charWidth == 0) return new LogBuffer(0, 0);

            int visibleWidth = listBox.ClientSize.Width;
            int visibleHight = listBox.ClientSize.Height;
            
            return new LogBuffer(visibleWidth / charWidth - 4, visibleHight / charHeight - 1);
        }

        public void ClearLog()
        {
            StatusLogListBox.Items.Clear();
        }
    }
}
