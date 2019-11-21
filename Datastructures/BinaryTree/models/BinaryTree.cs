using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeApp.models;

namespace BinaryTreeApp.models
{
    class BinaryTree
    {

        private BinaryTreeItem _root;
        //neues Kommentar 

        //Add 
        public void Add(int? itemToAdd)
        {

            if (itemToAdd == null)
            {
                return;
            }

            if (this._root == null)
            {
                this._root = new BinaryTreeItem(itemToAdd, null, null);
                return;
            }

            BinaryTreeItem tmp = this._root;
            while (tmp != null)
            {
                if (tmp.Item.Equals(itemToAdd))
                {
                    tmp.Counter++;
                    return;
                }

                if (itemToAdd > tmp.Item)
                {
                    if (tmp.NextRightItem == null)
                    {
                        tmp.NextRightItem = new BinaryTreeItem(itemToAdd, null, null);
                        return;
                    }
                    tmp = tmp.NextRightItem;

                }

                if (itemToAdd < tmp.Item)
                {
                    if (tmp.NextLeftItem == null)
                    {
                        tmp.NextLeftItem = new BinaryTreeItem(itemToAdd, null, null);
                        return;
                    }

                    tmp = tmp.NextLeftItem;
                }



            }
        }
        //Find 
        public BinaryTreeItem FindItem(int itemToFind)
        {
            //1.Fall
            if (this._root == null)
            {
                return null;
            }
            //2.Fall
            BinaryTreeItem tmp = this._root;

            while (tmp != null)
            {


                if (tmp.Item > itemToFind)
                {
                    tmp = tmp.NextLeftItem;
                }
                if (tmp.Item < itemToFind)
                {
                    tmp = tmp.NextRightItem;

                }
                if (tmp.Item == itemToFind)
                {

                    return tmp;
                }

            }
            return null;
        }
        //Min
        public BinaryTreeItem Minimum(int itemToFind)
        {
            if (this._root == null)
            {
                return null;
            }

            BinaryTreeItem foundItem = FindItem(itemToFind);
            if (foundItem == null)
            {
                return null;
            }
            while (foundItem != null)
            {
                if (foundItem.Item.Equals(itemToFind))
                {
                    if (foundItem.NextLeftItem != null)
                        foundItem = foundItem.NextLeftItem;
                }

                return foundItem;
            }
            return null;
        }
        //Max
        public BinaryTreeItem Maximum()
        {
            if (this._root == null)
            {
                return null;
            }

            BinaryTreeItem tmp = this._root;
            while (tmp != null)
            {
                if (tmp.Item != null)
                {
                    tmp = tmp.NextRightItem;
                }

                return tmp;

            }

            return null;
        }

        //ADD-rekursiv 
        public void AddRecursive(int? itemToAdd, BinaryTreeItem nextValue)
        {
            AddRecursiveIntern(itemToAdd, _root);
        }
        private void AddRecursiveIntern(int? itemToAdd, BinaryTreeItem nextValue)
        {
            if (this._root == null)
            {
                this._root = new BinaryTreeItem(itemToAdd, null, null);
                //counter ++; 
                return;
            }
            if (itemToAdd == nextValue.Item)
            {
                nextValue.Counter++;
                //Counter ++; 
                return;
            }
            if (itemToAdd < nextValue.Item)
            {
                if (nextValue.NextLeftItem == null)
                {
                    nextValue.NextLeftItem = new BinaryTreeItem(itemToAdd, null, null);
                    //counter ++; 
                    return;
                }
                AddRecursiveIntern(itemToAdd, nextValue.NextLeftItem);
            }
            else if (itemToAdd > nextValue.Item)
            {
                if (nextValue.NextRightItem == null)
                {
                    nextValue.NextRightItem = new BinaryTreeItem(itemToAdd, null, null);
                }
            }
            AddRecursiveIntern(itemToAdd, nextValue.NextRightItem);
        }

        //MAX-rekursiv 
        public BinaryTreeItem Maximumrekursive(double? startValue = null)
        {
            return MaximumrekursiveIntern();
        }
        private BinaryTreeItem MaximumrekursiveIntern(int? startValue = null, BinaryTreeItem actItem = null)
        {

            if (actItem == null)
            {
                if (startValue != null)
                {
                    actItem = FindItem(startValue.Value);
                }


                else
                {
                    actItem = this._root;
                }
            }

            else
            {

                actItem = actItem.NextRightItem;
            }

            if (actItem == null)
            {
                return null;
            }


            if (actItem.NextRightItem == null)
            {
                return actItem;
            }

            else
            {
                return MaximumrekursiveIntern(startValue, actItem);
            }
        }

        //FIND-rekursiv
        public BinaryTreeItem FindRecursive(int? itemToFind, BinaryTreeItem currentValue)
        {
            if (this._root == null)
            {
                return null;
            }

            return FindRecursiveIntern(itemToFind, _root);
        }
        private BinaryTreeItem FindRecursiveIntern(int? itemToFind, BinaryTreeItem currentValue)
        {
            if (this._root == null)
            {
                return null;
            }
            if (itemToFind == currentValue.Item)
            {
                return currentValue;
            }

            else if (itemToFind < currentValue.Item)
            {
                return FindRecursiveIntern(itemToFind, currentValue.NextRightItem);
            }

            else if (itemToFind > currentValue.Item)
            {
                return FindRecursiveIntern(itemToFind, currentValue.NextLeftItem);
            }

            return null;
        }
    
        //MIN-rekursiv
        public BinaryTreeItem Minimumrekursive(double? startValue = null)
        {
            return MinimumrekursiveIntern();
        }
        private BinaryTreeItem MinimumrekursiveIntern(int? startValue = null, BinaryTreeItem actItem = null)
        {

            if (actItem == null)
            {
                if (startValue != null)
                {
                    actItem = FindItem(startValue.Value);
                }


                else
                {
                    actItem = this._root;
                }
            }

            else
            {

                actItem = actItem.NextLeftItem;
            }

            if (actItem == null)
            {
                return null;
            }


            if (actItem.NextLeftItem == null)
            {
                return actItem;
            }

            else
            {
                return MinimumrekursiveIntern(startValue, actItem);
            }
        }

        //FindBefore 
        public BinaryTreeItem FindBefore(int itemToFind, out bool isRoot)
        {
            isRoot = false;
            if (this._root == null)
            {
                return null; 
            }
            if(this._root.Item == itemToFind)
            {
                isRoot = true;
                return null;
            }

            BinaryTreeItem tmp = this._root;

            while (tmp != null)
            {


                if (tmp.NextLeftItem.Item > itemToFind)
                {
                    tmp = tmp.NextLeftItem;
                }
                if (tmp.NextRightItem.Item < itemToFind)
                {
                    tmp = tmp.NextRightItem;

                }
                if ((tmp.NextLeftItem.Item == itemToFind)||(tmp.NextRightItem.Item == itemToFind))
                {

                    return tmp;
                }

            }
            return null;

        }

        //Remove 
        public bool Remove(int? itemToRemove, int? itemToFind)
        {
           if(itemToRemove== null)
            {
                return false;
            }

           if(itemToFind== null)
            {
                return false;
            }

            return true;
            
            //1.Fall
           
        }
        public bool Remove2(int? itemToRemove, int? itemToFind)
        {
            if (itemToRemove == null)
            {
                return false;
            }

            if (itemToFind == null)
            {
                return false;
            }

            return true;

            //1.Fall

        }

        //ToString
    }

}


