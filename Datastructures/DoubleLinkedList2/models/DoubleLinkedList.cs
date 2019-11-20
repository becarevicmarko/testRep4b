using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList2.models
{
    class DoubleLinkedList<T> where T : class
    {
        private DoubleLinkedListItem<T> _firstItem;
        private DoubleLinkedListItem<T> _lastItem;

        public DoubleLinkedList()
        {
            this._firstItem = null;
            this._lastItem = null;
        }

        public DoubleLinkedList(T item)
        {
            this._firstItem = new DoubleLinkedListItem<T>(item, null,null);
            this._lastItem = _firstItem;
        }

        public DoubleLinkedList(DoubleLinkedList<T> dll)
        {
            this._firstItem = dll._firstItem;
            this._lastItem = dll._lastItem;
        }
        

        //Add
        public bool Add(T itemToAdd)
        {
            //Parameter überprüfen
            if (itemToAdd == null)
            {
                return false;
            }

            //1.Fall----Das zu hinzufügende Item ist das firstItem
            if(this._firstItem == null)
            {
                this._firstItem = new DoubleLinkedListItem<T>(itemToAdd, null, null);
                this._lastItem = this._firstItem;
                
            }

            //2.Fall
            else
            {
                this._lastItem.NextItem = new DoubleLinkedListItem<T>(itemToAdd, null, this._lastItem);
                this._lastItem = this._lastItem.NextItem;
                
            }
            return true;
        }
        
        //AddItemBeforeItem
        public bool AddItemBeforeItem(T itemToAdd, T itemToFind)
        {
            if (itemToAdd == null)
            {
                return false;
            }
            if (itemToFind == null)
            {
                return false;
            }
            if (this._firstItem == null)
            {
                return Add(itemToAdd);
            }

            DoubleLinkedListItem<T> foundItem = FindItem(itemToFind);

            if(foundItem== null)
            {
                return Add(itemToAdd);
            }
            if(foundItem == this. _firstItem)
            {
                foundItem.ItemBefore = new DoubleLinkedListItem<T>(itemToAdd, this._firstItem, null);
                this._firstItem = this._firstItem.ItemBefore;
                return true;
            }

            else
            {
                DoubleLinkedListItem<T> newItem = new DoubleLinkedListItem<T>(itemToAdd, foundItem , foundItem.ItemBefore);
                foundItem.ItemBefore = newItem;
                newItem = newItem.ItemBefore.NextItem;
                return true;
            }




        }
        //AddItemAfterItem
        public bool AddItemAfterItem(T itemToAdd,T itemToFind)
        {
            //Parameter überprüfen
            if(itemToAdd == null)
            {
                return false;
            }
            if(itemToFind== null)
            {
                return false;
            }
            if (this._firstItem == null)
            { 
                return Add(itemToAdd);
            }


            DoubleLinkedListItem<T> foundItem = FindItem(itemToFind);

            if(foundItem == null)
            {
                return Add(itemToAdd);
            }

            if(foundItem == this._lastItem)
            {
                this._lastItem.NextItem = new DoubleLinkedListItem<T>(itemToAdd, null, this._lastItem);
                this._lastItem = this._lastItem.NextItem;
            }
            else
            {
                DoubleLinkedListItem<T> newItem = new DoubleLinkedListItem<T>(itemToAdd, foundItem.NextItem, foundItem);
                foundItem.NextItem = newItem;
                newItem = newItem.NextItem.ItemBefore;
            }


            return true;
        } 

        //FindItem 
        public DoubleLinkedListItem<T> FindItem (T itemToFind)
        {
            if(itemToFind == null)
            {
                return null;
            }
            if (this._firstItem == null)
            {
                return null;
            }

            DoubleLinkedListItem<T> tmp = this._firstItem;

            while(tmp != null)
            {

                if(tmp.Item.Equals(itemToFind))
                {
                    return tmp;
                }
                tmp = tmp.NextItem;
            }
            return null;
        }

        //Change 
        public bool Change(T itemToChange,T newItemData)
        {
            if ((itemToChange == null) || (newItemData == null) || (this._firstItem == null))
            {
                return false;
            }


            DoubleLinkedListItem<T> foundItem = FindItem(itemToChange);


            if(foundItem== null)
            {
                return false;
            }

            else
            {
                foundItem.Item = newItemData;
                return true;
            }
        }

        //Remove
        public bool Remove(T itemToRemove)
        {
            //Parameter überprüfen 
            if ((itemToRemove == null) || (this._firstItem == null))
            {
                return false;
            }

            //1.Fall ---itemToRemove == firstItem
            if (this._firstItem.Equals(itemToRemove))
            {

                this._firstItem.NextItem.ItemBefore = null;
                this._firstItem = this._firstItem.NextItem;
            }

            //2.Fall ---itemToRemove == lastItem
            if (this._lastItem.Equals(itemToRemove))
            {
                this._lastItem = this._lastItem.ItemBefore;
                this._lastItem.NextItem = null;
            }
            //3.Fall itemToRemove ist irgendwo dazwischen

            DoubleLinkedListItem<T> foundItem = FindItem(itemToRemove);

            if (foundItem == null)
            {
                return false;
            }
            else
            {
                foundItem.ItemBefore.NextItem = foundItem.NextItem;
                foundItem.NextItem.ItemBefore = foundItem.ItemBefore;
                return true;
            }
        }

            //Find-Rekursiv 
            public DoubleLinkedListItem<T> FindRekursiv(T itemToFind, DoubleLinkedListItem<T> actItem = null)
            {

                if(itemToFind== null)
                {
                    return null;
                }

                if(_firstItem== null)
                {
                    return null;

                }

                if(actItem== null)
                {
                    actItem = this._firstItem;
                }

                else
                {
                    actItem = actItem.NextItem;
                }

                if(actItem== null)
            {
                return null;
            }

                else if (actItem.Item.Equals(itemToFind))
            {

                return actItem;
            }

            else
            {
                return FindRekursiv(itemToFind, actItem);
            }


        }
        //To-String-Methode
        public override string ToString()
        {
            string s = "";

            if (this._firstItem != null)
            {
                DoubleLinkedListItem<T> actItem = this._firstItem;
                while (actItem != null)
                {
                    s += actItem.Item.ToString() + "\n";
                    actItem = actItem.NextItem;
                }

                if (s == "")
                {
                    return "no item";
                }
            }

            return s;
        }
        
    }
}
