using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList2.models
{
    class SingleLinkedList<T> where T: class
    {
        private SingleLinkedListItem<T> _firstItem;
        private SingleLinkedListItem<T> _lastItem;



        public SingleLinkedList()
        {
            this._firstItem = null;
            this._lastItem = null;
        }

        public SingleLinkedList(T item)
        {
            this._firstItem = new SingleLinkedListItem<T>(item, null);
            this._lastItem = _firstItem;
        }

        public SingleLinkedList(SingleLinkedList<T> sll)
        {
            this._firstItem = sll._firstItem;
            this._lastItem = sll._lastItem;
        }
             
        public bool Add(T itemToAdd)
        {
            if(itemToAdd == null)
            {
                return false;
            }

            //1.Fall
            if(this._firstItem == null)
            {
                this._firstItem = new SingleLinkedListItem<T>(itemToAdd, null);
                this._lastItem = this._firstItem;
            }


            //2.Fall
            else
            {
                this._lastItem.NextItem = new SingleLinkedListItem<T>(itemToAdd,null);
                this._lastItem = this._lastItem.NextItem;
            }

            return true;
        }
        
        public bool AddItemAfterItem(T itemToAdd, T itemToFind)
        {
            if(itemToAdd== null)
            {
                return false;
            }
            if(itemToFind == null)
            {
                return Add(itemToAdd);
            }

            SingleLinkedListItem<T> foundItem = FindItem(itemToFind);
            if(foundItem == null)
            {
                return Add(itemToAdd);

            }

            if(foundItem == this._lastItem)
            {
                this._lastItem.NextItem = new SingleLinkedListItem<T>(itemToAdd, null);
                this._lastItem = this._lastItem.NextItem;

            }
            else
            {
                SingleLinkedListItem<T> newItem = new SingleLinkedListItem<T>(itemToAdd, foundItem.NextItem);
                foundItem.NextItem = newItem;
                newItem = foundItem.NextItem.NextItem;
  
            }

        
            return false;
        }

        public SingleLinkedListItem<T> FindItem(T itemToFind)
        {
            if (itemToFind == null)
            {
                return null;
            }

            else
            {
                
                SingleLinkedListItem<T> tmp = this._firstItem;

                while (tmp != null)
                {
                    
                    if(tmp.Item.Equals(itemToFind))
                    {
                        return tmp;
                    }

                    tmp = tmp.NextItem;
                }
                return null;
            }
        }

        public SingleLinkedListItem<T> FindItemBeforeItem(T itemToFind, out bool isStartItem)
            
        {
            isStartItem = false; 

            if (itemToFind == null)
            {
                return null;
            }

            if (this._firstItem == null)
            {
                return null;
            }
            if (this._firstItem.Item.Equals(itemToFind))
            {
                isStartItem = true;
                return null;

            }

            else
            {
                SingleLinkedListItem<T> tmp = this._firstItem;

                
                while (tmp != null)
                {
                    if (tmp.NextItem != null)
                    {
                        if ((tmp.NextItem != null)&& (tmp.NextItem.Item.Equals(itemToFind)))
                        {
                            return tmp;
                        }

                        tmp = tmp.NextItem;
                    }
                    
                }
                return null;
            }
        }

        public bool Remove(T itemToRemove)
            
        {
            if(itemToRemove== null)
            {
                return false; 
            }
            // es existiert noch kein Eintrag in der Liste 
            if(this._firstItem== null)
            {
                return false;
            }
            //1.Fall
            //erster Eintrag ist der gesuchte Eintrag 
            bool isStartItem;
            SingleLinkedListItem<T> itemBeforeItemToRemove = FindItemBeforeItem(itemToRemove, out isStartItem);

            //Item ist nicht vorhanden
            if((itemBeforeItemToRemove == null)&& !isStartItem){

                return false;

            }
            //Gesuchter Eintrag ist erster Eintrag 

            if (isStartItem)
            {
                this._firstItem = this._firstItem.NextItem;
                return false;
            }
           
            //letzter Eintrag

            if(itemBeforeItemToRemove.NextItem.NextItem == null)
            {
                this._lastItem = itemBeforeItemToRemove;
                this._lastItem.NextItem = null;
                return true;
            }

            ,
            //irgendwo zwischen first- und lastItem 
            else
            {
                itemBeforeItemToRemove.NextItem = itemBeforeItemToRemove.NextItem.NextItem;
                return true;
            }
                 
        }

        public bool ChangeData(T itemToReplace, T newItemData)
        {

            if ((itemToReplace == null) || (newItemData == null) || (this._firstItem == null))
            {
                return false;
            }

            SingleLinkedListItem<T> itemToChange = FindItem(itemToReplace);

            if (itemToChange == null)
            {
                return false;
            }
            else
            {
                itemToChange.Item = newItemData;
                return true;
            }
        }


        public override string ToString()
        {
            string s = "";

            if(this._firstItem != null)
            {
                SingleLinkedListItem<T> actItem = this._firstItem;
                while (actItem != null)
                {
                    s += actItem.Item.ToString() + "\n";
                    actItem = actItem.NextItem;
                }

                if(s == "")
                {
                    return "no item";
                }
            }

            return s;
        }

        
    }
}
