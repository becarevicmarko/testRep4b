using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp.models
{
    class BinaryTreeItem
    {
        public int? Item { get; set; }
        public BinaryTreeItem NextLeftItem { get; set; }
        public BinaryTreeItem NextRightItem { get; set; }
      
        public int Counter { get; set; }

        public BinaryTreeItem() : this(null, null, null) { }      
        public BinaryTreeItem(int? item, BinaryTreeItem nextRightItem, BinaryTreeItem nextLeftItem)
        {
            this.Item = item;
            this.NextLeftItem = nextLeftItem;
            this.NextRightItem = nextRightItem;
            if (item == null)
            {
                this.Counter = 0;
            }
            else
            {
                this.Counter = 1;
            }
        }

        //To-String 

        public override string ToString()
        {
            if (this.Item == null)
            {
                return "Leerer Eintrag" + " (" + this.Counter + ") ";
            }
            else
            {
                return this.Item + " (" + this.Counter + ") ";
            }
        }

    }
}
