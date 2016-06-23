using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Elements;
using ProceduralWorldGeneration.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class WorldGenerator : INotifyPropertyChanged
    {
        ElementGroups elementgroups = new ElementGroups();

        private World _generated_world;
        public World GeneratedWorld
        {
            get
            {
                return _generated_world;
            }
            set
            {
                if (value != _generated_world)
                {
                    _generated_world = value;
                    NotifyPropertyChanged("GeneratedWorld");
                }
            }
        }

        private Queue<Element> generation_queue;

        public void InitializeWorldGenerator()
        {
            generation_queue = new Queue<Element>();
            _generated_world = new World();
            MainInputReader reader = new MainInputReader(elementgroups);
        }

        public void generateWorld()
        {
            Element current_element;
            // Add the first element to seed the world. Currently a super region.
            GeneratedWorld.BaseElement = new Element(elementgroups.Elements[0][ConfigValues.RandomGenerator.Next(elementgroups.Elements[0].Count)]);
            GeneratedWorld.ElementCollection.Add(GeneratedWorld.BaseElement);
            generation_queue.Enqueue(GeneratedWorld.BaseElement);
            //OnNewElementCreated(GeneratedWorld.BaseElement);

            while (!(generation_queue.Count == 0))
            {
                int fill = 0;
                current_element = generation_queue.Dequeue();
                current_element.Size = ConfigValues.RandomGenerator.Next(current_element.MinSize, current_element.MaxSize) * 10;
                while (fill < current_element.Size)
                {
                    int temp = generateElement(current_element);
                    if (temp == -1)
                    {
                        break;
                    }
                    else
                    {
                        fill += temp;
                    }
                }
            }

            OnEndedGeneration("All Elements have been generated.");
        }

        private int generateElement(Element current_element)
        {
            List<Element> source_elements = createSourceElementList(elementgroups.Groups[current_element.GroupIdentifier - 1].SubGroups);
            if (source_elements.Count == 0)
            {
                return -1;
            }
            Element current_child_element = new Element(source_elements[ConfigValues.RandomGenerator.Next(source_elements.Count)]);
            // Add parent and size to object.
            current_child_element.ParentElement = current_element;
            current_child_element.Size = ConfigValues.RandomGenerator.Next(current_child_element.MinSize, current_child_element.MaxSize);

            // adds the element to the list
            current_element.ChildElements.Add(current_child_element);

            // Add new element to queue
            generation_queue.Enqueue(current_child_element);

            // Add to global list
            GeneratedWorld.ElementCollection.Add(current_child_element);

            // Update log
            //OnNewElementCreated(current_child_element);

            // determines how much this element fills the parent
            return current_child_element.Size;
        }

        // Gathers all the elements from the subgroups. One of these elements is then spawned to be added to the current_element.
        private List<Element> createSourceElementList(List<Group> group_ids)
        {
            List<Element> elements  = new List<Element>();
            foreach (Group g in group_ids)
            {
                foreach (Element e in elementgroups.Elements[g.Identifier - 1])
                {
                    elements.Add(e);
                }
            }
            return elements;
        }



        public delegate void CreatedNewElement(string status);
        public delegate void EndedGeneration(string status);

        public event EndedGeneration endedGeneration;
        public event CreatedNewElement createdNewElement;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnNewElementCreated(Element element)
        {
            if (createdNewElement != null)
            {
                createdNewElement("An " + element.Name + " was generated!\n");
            }

        }
        public void OnEndedGeneration(string status)
        {
            if (endedGeneration != null)
            {
                endedGeneration(status);
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
