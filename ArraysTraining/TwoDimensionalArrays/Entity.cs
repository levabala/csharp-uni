using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDimensionalArrays
{
    class Entity
    {
        public Func<Entity[], Entity> processor;
        public string staticValue;
        public bool isStatic;
        public string name;

        public Entity(string name, Func<Entity[], Entity> processor)
        {
            this.name = name;
            this.processor = processor;
            isStatic = false;
        }

        public Entity(string name, string staticValue)
        {
            this.name = name;
            this.staticValue = staticValue;
            
            isStatic = true;
        }

        public Entity execute(Entity[] entities)
        {
            if (isStatic)
                return this;

            return processor(entities);
        }

        public string getValue()
        {
            return isStatic ? staticValue : name;
        }
    }
}
