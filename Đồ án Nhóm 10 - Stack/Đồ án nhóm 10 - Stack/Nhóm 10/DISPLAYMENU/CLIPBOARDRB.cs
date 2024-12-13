using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CLIPBOARD_CLASS
{
    public class CLIPBOARDRB
    {
        public class ClipboardRB<T>
        {
            private object[] ms;
            private int top;
            private string filePath = @"C:\Users\GODxDEMON\Downloads\DSA-master (2) (1)\DSA-master\DSA-master\DISPLAYMENU\Resources\Temp.txt";
            private const int MaxStackSize = 3;

            public ClipboardRB()
            {
                ms = new object[MaxStackSize];
                top = -1;
                LoadStackFromFile();
            }

            public void Add(string input, string selected)
            {
                if (top == MaxStackSize - 1)
                {
                    for (int i = 0; i < top; i++)
                    {
                        ms[i] = ms[i + 1];
                    }
                    top--;
                }
                top++;
                ms[top] = string.IsNullOrEmpty(selected) ? input : selected;
                SaveStackToFile();
            }

            public string Paste(string result)
            {
                if (top >= 0)
                {
                    result += ms[top].ToString();
                    ms[top] = null;
                    top--;
                    SaveStackToFile();
                }
                else
                {
                    MessageBox.Show("Đã hết phần tử trong ngăn xếp Stack");
                }
                return result;
            }

            public void SaveStackToFile()
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    for (int i = 0; i <= top; i++)
                    {
                        writer.WriteLine(ms[i]);
                    }
                }
            }

            public void LoadStackFromFile()
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    top = -1;
                    foreach (var line in lines)
                    {
                        if (top < MaxStackSize - 1)
                        {
                            top++;
                            ms[top] = line;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            public void ClearStack()
            {
                for (int i = 0; i <= top; i++)
                {
                    ms[i] = null;
                }
                top = -1;
                SaveStackToFile();
            }

            public string ClearInput(string input)
            {
                return string.Empty;
            }

            public object[] GetStackState()
            {
                return ms.Take(top + 1).ToArray(); // Lấy trạng thái hiện tại của stack
            }

            public void RestoreStackState(object[] state)
            {
                top = state.Length - 1;
                for (int i = 0; i <= top; i++)
                {
                    ms[i] = state[i];
                }
                SaveStackToFile(); // Lưu lại trạng thái sau khi khôi phục
            }

        }
    }
}
