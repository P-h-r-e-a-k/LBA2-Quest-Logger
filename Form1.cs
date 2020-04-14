using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LBA2_Quest_Logger
{
    public partial class Form1 : Form
    {
        LBA2Quests quests;
        OffsetValue[] previous;
        LBAMemoryModule.Mem m = new LBAMemoryModule.Mem();
        public Form1()
        {
            InitializeComponent();
            SetDoubleBuffered(lvQuest);
            SetDoubleBuffered(lvSubquest);
            quests = new LBA2Quests(getLBAFilesPath());
            load(true);
        }
        private string getQuestFilePath()
        {
            return getLBAFilesPath() + "Quests.xml";
        }
        #region setDoubleBuffered
        /**
         * Used to stop flickering on interface update
         * caused by constantly updating with times
         */
        public static void SetDoubleBuffered(Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        #endregion

        private string getLBAFilesPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "files\\";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load(false);
        }

        private void load(bool padQuest)
        {
            int QuestSelectedIndex = -1;
            int SubquestSelectedIndex = -1;
            if (0 != lvQuest.SelectedItems.Count)
                QuestSelectedIndex = lvQuest.SelectedItems[0].Index;
            if (0 != lvSubquest.SelectedItems.Count)
                SubquestSelectedIndex = lvSubquest.SelectedItems[0].Index;
            if (padQuest)
            {
                addOrUpdateQuest(padQuests(quests));
            }
            else
            {
                addOrUpdateQuest(quests);
            }
            //txtQuestDescription.Text = "";
            //txtSubquestDescription.Text = "";
            if(-1 != QuestSelectedIndex)
                lvQuest.Items[QuestSelectedIndex].Selected = true;
            if (-1 != SubquestSelectedIndex)
                lvSubquest.Items[SubquestSelectedIndex].Selected = true;
        }

        private LBA2Quests padQuests(LBA2Quests input)
        {
            uint count = ((input.quests[input.quests.Count()-1].memoryOffset - input.quests[0].memoryOffset ) + 1)/2;
            
            LBA2Quest[] output = new LBA2Quest[count+1];
            //for (int i = 0, j = 0; i < count; i++)

            for (int i = 0, copied = 0; i < output.Count(); i++)
            {
                //Always copy first item (No previous item to compare against
                if (0 != i && ((input.quests[copied].memoryOffset - 2) > output[i - 1].memoryOffset))
                {
                    output[i] = new LBA2Quest("Unknown", output[i - 1].memoryOffset + 2, 1, null);//pad item;
                }
                else
                    output[i] = input.quests[copied++];//Copy item and increment source index
            }
            input.quests = output;
            return input;
        }

        private void addOrUpdateQuest(LBA2Quests quests)
        {
            if (0 == lvQuest.Items.Count)
                addQuestsToListView(quests);
            else
                updateQuests(quests);
        }
        private void updateQuests(LBA2Quests quests)
        {
            for (int i = 0; i < quests.quests.Count(); i++)
                if (lvQuest.Items[i].SubItems[0].Text != quests.quests[i].name)
                {
                    lvQuest.Items[i].SubItems[1].Text = quests.quests[i].name;
                    lvQuest.Items[i].Tag = quests.quests[i];
                }
        }

        private void addQuestsToListView(LBA2Quests quests)
        {
            lvQuest.Items.Clear();
            
            for (int i = 0; i < quests.quests.Count(); i++) 
                addQuestToListView(quests.quests[i]);
        }

        private void addQuestToListView(LBA2Quest quest)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = quest.memoryOffset.ToString("X2");
            lvi.SubItems.Add(quest.name);
            lvi.Tag = quest;
            lvQuest.Items.Add(lvi);
        }

        private void addSubquestsToListView(LBA2Quest.Subquest[] sq)
        {
            lvSubquest.Items.Clear();
            if (null == sq) return;
            for (int i = 0; i < sq.Count(); i++)
                addSubquestToListView(sq[i]);
        }

        private void addSubquestToListView(LBA2Quest.Subquest sq)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = sq.name;
            lvi.SubItems.Add(sq.value.ToString());
            lvi.Tag = sq;
            lvSubquest.Items.Add(lvi);
        }

        private void lvQuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 == lvQuest.SelectedItems.Count)
            {
                txtQuestDescription.Text = "";
                lvSubquest.Items.Clear();
                return; //If nothing selected bail out
            }

            addSubquestsToListView(((LBA2Quest)lvQuest.SelectedItems[0].Tag).subquests);
            txtQuestDescription.Text = lvQuest.SelectedItems[0].SubItems[1].Text;
            txtOffset.Text = lvQuest.SelectedItems[0].SubItems[0].Text;
        }

        private void lvSubquest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 == lvSubquest.SelectedItems.Count)
                txtSubquestDescription.Text = "";
            else
                txtSubquestDescription.Text = lvSubquest.SelectedItems[0].SubItems[0].Text;
        }

        private void btnQuestDescUpdate_Click(object sender, EventArgs e)
        {
            if (0 == lvQuest.SelectedItems.Count) return;
            quests.quests[lvQuest.SelectedItems[0].Index].name = txtQuestDescription.Text;
            load(false);
        }

        private void btnSubquestDescUpdate_Click(object sender, EventArgs e)
        {
            if (0 == lvSubquest.SelectedItems.Count) return;
            quests.quests[lvQuest.SelectedItems[0].Index].subquests[lvSubquest.SelectedItems[0].Index].name = txtSubquestDescription.Text;
            lvSubquest.SelectedItems[0].Text = txtSubquestDescription.Text;
            load(false);
        }

        private void save()
        {
            string path = getQuestFilePath();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.IndentChars = ("\t");
            xmlWriterSettings.NewLineOnAttributes = false;
            xmlWriterSettings.Encoding = Encoding.GetEncoding("ISO-8859-1");

            if (File.Exists(path))
                File.Delete(path);
            using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
            {

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("quests");

                for (int i = 0; i < lvQuest.Items.Count; i++)
                {
                    xmlWriter.WriteStartElement("quest");
                    xmlWriter.WriteComment(((LBA2Quest)lvQuest.Items[i].Tag).name);
                        xmlWriter.WriteStartElement("name");
                            xmlWriter.WriteString(((LBA2Quest)lvQuest.Items[i].Tag).name);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("memoryOffset");
                            xmlWriter.WriteString(((LBA2Quest)lvQuest.Items[i].Tag).memoryOffset.ToString("X2"));
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("size");
                            xmlWriter.WriteString(((LBA2Quest)lvQuest.Items[i].Tag).size.ToString());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("subquests");

                        for (int j = 0; j < ((LBA2Quest)lvQuest.Items[i].Tag).subquests.Count(); j++)
                        {
                            xmlWriter.WriteStartElement("subquest");
                                xmlWriter.WriteStartElement("name");
                                    xmlWriter.WriteString(((LBA2Quest)lvQuest.Items[i].Tag).subquests[j].name);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("value");
                                    xmlWriter.WriteString(((LBA2Quest)lvQuest.Items[i].Tag).subquests[j].value.ToString());
                                xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndElement();
                        }
                        xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
        Timer t;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Start/Stop - if null, stop
            if(null != t)
            {
                t.Enabled = false;
                t.Dispose();
                t = null;
                btnStart.Text = "Start";
            }
            else
            {
                t = new Timer();
                t.Interval = 500;
                t.Tick += t_Tick;
                t.Enabled = true;
                btnStart.Text = "Stop";
            }
        }

        public void t_Tick(object sender, EventArgs e)
        {
            t.Enabled = false;
            byte[] data;
            ushort size = (ushort)((quests.quests.Count()*2) +1);
            data = m.getByteArray(quests.quests[0].memoryOffset, size);
            if (null == previous) previous = new OffsetValue[quests.quests.Count()];
            for (int i = 0; i < quests.quests.Count(); i++)
            {
                if(null == previous[i])
                {
                    previous[i] = new OffsetValue(quests.quests[i].memoryOffset, data[i * 2]);
                }
                
                int subItemPos = getSubitemIndex(previous[i]);
                if (-1 == subItemPos)
                {
                    if (ignoreItem(quests.quests[i].memoryOffset)) continue;
                    quests.quests[i].subquests = addNewSubitem(quests.quests[i], new OffsetValue(quests.quests[i].memoryOffset, data[i * 2]));
                    load(false);
                    int subitemID = getSubitemIndex(new OffsetValue(quests.quests[i].memoryOffset, data[i * 2]));
                    //lvQuest.SelectedItems[i].Selected = true;
                    //lvSubquest.SelectedItems[subitemID].Selected = true;
                }
                previous[i] = new OffsetValue(quests.quests[i].memoryOffset, data[i * 2]);
                
            }

            load(false);

            t.Enabled = true;
        }

        private bool ignoreItem(uint offset)
        {
            uint[] ignoreList = new uint[2];
            ignoreList[0] = 0x57C93; //Wizard peddler position
            ignoreList[1] = 0x57DE9; //Clovers
            return ignoreList.Contains(offset);
        }

        //Return -1 if doesn't exist, else return index in lvSubquest.Items
        private sbyte getSubitemIndex(OffsetValue ov)
        {
            LBA2Quest.Subquest[] sqs;
            int questOffset = 0;
            while (ov.offset != quests.quests[questOffset++].memoryOffset);

            //Check subitems
            sqs = quests.quests[--questOffset].subquests;
            if (null == sqs) return -1;
            for (sbyte i = 0; i < sqs.Count(); i++)
                if (sqs[i].value == ov.value)
                {
                    return i;
                }
            return -1;
        }


        //Add new subquest to the subquest array of the quest where
        //OffsetValue.offset = quest.offset
        private LBA2Quest.Subquest[] addNewSubitem(LBA2Quest q, OffsetValue ov)
        {
            //No previous items
            if (null == q.subquests)
            {
                q.subquests = new LBA2Quest.Subquest[1];
                q.subquests[0] = new LBA2Quest.Subquest("New", ov.value);
                return q.subquests;
            }
            else
            {
                LBA2Quest.Subquest[] additional = new LBA2Quest.Subquest[q.subquests.Count() + 1];
                int copied = 0;
                int i = 0;

                for (copied = 0; copied < additional.Count(); copied++)
                {
                    //Insert new in correct place and copy rest
                    if
                    (
                        null == ov || //Already done it
                        (
                            q.subquests.Count() != i && //Not already copied everything (must be new)
                            ov.value > q.subquests[i].value
                        )
                    )
                    {
                        additional[copied] = q.subquests[i];
                        i++;
                    }
                    else
                    {
                        LBA2Quest.Subquest[] sq = new LBA2Quest.Subquest[1];
                        sq[0] = new LBA2Quest.Subquest("New", ov.value);
                        GetSubItem gsi = new GetSubItem(new LBA2Quest(q.name, q.memoryOffset, q.size, sq));
                        gsi.ShowDialog();
                        if (null == gsi.q) return null; //If we cancel the form ignore
                        q.name = gsi.q.name;
                        additional[copied] = gsi.q.subquests[0];
                        gsi.Dispose();
                        ov = null;
                    }
                }
                return additional;
            }
        }

        private LBA2Quest getNewSubquest()
        {
            return null;
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            OffsetValue ov = new OffsetValue();
            ov.offset = uint.Parse(txtOffset.Text, System.Globalization.NumberStyles.HexNumber);
            ov.value = ushort.Parse(txtValue.Text);
            int exists = getSubitemIndex(ov);
            if (-1 == exists)
            {
                MessageBox.Show("Doesn't exist");
                quests.quests[2].subquests = addNewSubitem(quests.quests[2], ov);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int questIndex = lvQuest.SelectedItems[0].Index;
            if(0 == questIndex) return;

            LBA2Quest q = quests.quests[questIndex];

            OffsetValue ov = new OffsetValue(q.memoryOffset, ushort.Parse(txtValue.Text));
            quests.quests[questIndex].subquests = addNewSubitem(quests.quests[questIndex], ov);
            load(false);
        }
    }


    class OffsetValue
    {
        public uint offset;
        public ushort value;

        public OffsetValue() { }
        public OffsetValue(uint offset, ushort value)
        {
            this.offset = offset;
            this.value = value;
        }
    }
}
