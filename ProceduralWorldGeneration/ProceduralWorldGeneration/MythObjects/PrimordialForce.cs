using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythActions;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneTypeSetters;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneElementSetters;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions;
using ProceduralWorldGeneration.Output;

namespace ProceduralWorldGeneration.MythObjects
{
    public class PrimordialForce : ActionTakerMythObject
    {
        private int _spawn_weight;
        public int SpawnWeight
        {
            get
            {
                return _spawn_weight;
            }
            set
            {
                if (_spawn_weight != value)
                {
                    _spawn_weight = value;
                    base.NotifyPropertyChanged("SpawnWeight");
                }
            }
        }

        private string _opposing;
        public string Opposing
        {
            get
            {
                return _opposing;
            }
            set
            {
                if (_opposing != value)
                {
                    _opposing = value;
                    base.NotifyPropertyChanged("Opposing");
                }
            }
        }


        private Plane _plane_construction;
        public Plane PlaneConstruction
        {
            get
            {
                return _plane_construction;
            }
            set
            {
                _plane_construction = value;
            }
        }

        public CreatePlaneCreationState PlaneConstructionState { get; set; }

        public PrimordialForce(string tag = "default_tag") : base(tag)
        {
            PlaneConstructionState = new CreatePlaneCreationState();

        }

        public override void takeAction(CreationMythState state, int current_year)
        {
            progressCooldowns();

            if (CurrentAction == null)
                determineNextAction(state);

            if (CurrentAction.getDuration() <= 0)
            {
                CreationMythLogger.updateActionLog(this);
                CurrentAction.Effect(state, this);
                CurrentAction.resetCooldown();
                CurrentAction.resetDuration();
                CurrentAction = null;
            }
            else
            {
                CurrentAction.reduceDuration();
            }
        }

        public override string ToString()
        {
            return "[" + Name + "]";
        }

        public override void buildExistingActionsTree()
        {
            _existing_actions.Add(new Tree<MythAction>(new CreatePlane()));
            _existing_actions[0].TreeRoot.AddChild(new SetCreator());
            _existing_actions[0].TreeRoot.AddChild(new FormPlane());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new DeterminePlaneType());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Value.AddChild(new SetMaterialType());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Value.AddChild(new SetElementalType());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Value.AddChild(new SetEtherealType());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Value.AddChild(new SetRandomType());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new DeterminePlaneSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Value.AddChild(new SetPocketSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Value.AddChild(new SetSmallSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Value.AddChild(new SetMediumSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Value.AddChild(new SetLargeSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Value.AddChild(new SetInfiniteSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Value.AddChild(new SetRandomSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Value.AddChild(new SetNoSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new DeterminePlaneElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Next.Value.AddChild(new SetAirElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Next.Value.AddChild(new SetEarthElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Next.Value.AddChild(new SetFireElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Next.Value.AddChild(new SetWaterElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Next.Value.AddChild(new SetLightElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Next.Value.AddChild(new SetDarknessElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Next.Value.AddChild(new SetRandomElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.Children.First.Next.Next.Value.AddChild(new SetNoElement());
            _existing_actions[0].TreeRoot.AddChild(new ConnectPlane());
            _existing_actions[0].TreeRoot.Children.First.Next.Next.Value.AddChild(new ConnectWithCoreWorld());
            _existing_actions[0].TreeRoot.Children.First.Next.Next.Value.AddChild(new ConnectWithInfinitePlane());
            _existing_actions[0].TreeRoot.Children.First.Next.Next.Value.AddChild(new ConnectWithMaterialWorld());
            _existing_actions[0].TreeRoot.Children.First.Next.Next.Value.AddChild(new ConnectWithNoPlane());
            _existing_actions[0].TreeRoot.Children.First.Next.Next.Value.AddChild(new ConnectWithRandomPlane());
            _existing_actions[0].TreeRoot.AddChild(new NamePlane());
            _existing_actions[0].TreeRoot.AddChild(new AddPlaneToUniverse());
        }
    }
}
