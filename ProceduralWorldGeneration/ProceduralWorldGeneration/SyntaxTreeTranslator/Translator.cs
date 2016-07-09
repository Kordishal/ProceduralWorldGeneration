﻿using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Parser;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.SyntaxTreeTranslator
{
    class Translator
    {
        private MythObjectData data { get; set; }
        private Tree<Expression> SyntaxTree { get; set; }      

        public Translator(Tree<Expression> syntax_tree)
        {
            SyntaxTree = syntax_tree;
        }

        public MythObjectData translate()
        {
            data = new MythObjectData();

            SyntaxTree.TreeRoot.traverseTree(translator);

            return data;
        }

        private void translator(TreeNode<Expression> current_node)
        {
            if (current_node.Value.ExpressionType == ExpressionTypes.Root)
            {
                return;
            }

            TreeNode<Expression> parent_node = current_node.Parent;
            TreeNode<Expression> first_child_node = current_node.GetFirstChild();
            TreeNode<Expression> last_child_node = current_node.GetLastChild();

            if (current_node.Value.ExpressionType == ExpressionTypes.Assignment)
            {
                if (parent_node.GetFirstChild().Value.ExpressionValue == "primordial_forces")
                {
                    PrimordialForce temp_primordial_force = new PrimordialForce(first_child_node.Value.ExpressionValue);
                    data.PrimordialForces.Add(temp_primordial_force);
                    data.DefinedMythObjects.Add(temp_primordial_force);
                }
                else if (parent_node.GetFirstChild().Value.ExpressionValue == "finite_plane_sizes")
                {
                    PlaneSize temp_plane_size = new PlaneSize(first_child_node.Value.ExpressionValue);
                    data.PlaneSizes.Add(temp_plane_size);
                    data.MythObjectAttributes.Add(temp_plane_size);
                }
                else if (parent_node.GetFirstChild().Value.ExpressionValue == "plane_types")
                {
                    PlaneType temp_plane_type = new PlaneType(first_child_node.Value.ExpressionValue);
                    data.PlaneTypes.Add(temp_plane_type);
                    data.MythObjectAttributes.Add(temp_plane_type);
                }
                else if (parent_node.GetFirstChild().Value.ExpressionValue == "plane_elements")
                {
                    PlaneElement temp_plane_elements = new PlaneElement(first_child_node.Value.ExpressionValue);
                    data.PlaneElements.Add(temp_plane_elements);
                    data.MythObjectAttributes.Add(temp_plane_elements);
                }
                else if (parent_node.GetFirstChild().Value.ExpressionValue == "traits")
                {
                    SpeciesTrait temp_trait = new SpeciesTrait(first_child_node.Value.ExpressionValue);
                    data.Traits.Add(temp_trait);
                    data.MythObjectAttributes.Add(temp_trait);
                }
                else if (parent_node.GetFirstChild().Value.ExpressionValue == "species_types")
                {
                    SpeciesType temp_species_type = new SpeciesType(first_child_node.Value.ExpressionValue);
                    data.SpeciesTypes.Add(temp_species_type);
                    data.MythObjectAttributes.Add(temp_species_type);
                }
                else if (parent_node.GetFirstChild().Value.ExpressionType == ExpressionTypes.Variable)
                {
                    BaseMythObject temp_myth_object = searchTag(parent_node.GetFirstChild().Value.ExpressionValue);

                    if (temp_myth_object != null)
                    {
                        if (typeof(PrimordialForce) == temp_myth_object.GetType())
                        {
                            PrimordialForce temp_primordial_force = (PrimordialForce)temp_myth_object;
                            if (first_child_node.Value.ExpressionValue == "name")
                            {
                                temp_primordial_force.Name = cutStringSigns(last_child_node.Value.ExpressionValue);
                            }
                            else if (first_child_node.Value.ExpressionValue == "spawn_weight")
                            {
                                temp_primordial_force.SpawnWeight = int.Parse(last_child_node.Value.ExpressionValue);
                            }
                        }
                    }
                    else
                    {
                        MythObjectAttribute temp_myth_object_attribute = searchAttributeTag(parent_node.GetFirstChild().Value.ExpressionValue);

                        if (temp_myth_object_attribute != null)
                        {
                            if (typeof(PlaneType) == temp_myth_object_attribute.GetType())
                            {
                                PlaneType temp_plane_type = (PlaneType)temp_myth_object_attribute;
                                if (first_child_node.Value.ExpressionValue == "name")
                                {
                                    temp_plane_type.Name = cutStringSigns(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "has_dominant_element")
                                {
                                    temp_plane_type.hasDominantElement = bool.Parse(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "is_attached_to")
                                {
                                    temp_plane_type.isAttachedTo = last_child_node.Value.ExpressionValue;
                                }
                                else if (first_child_node.Value.ExpressionValue == "is_infinite_only")
                                {
                                    temp_plane_type.isInfiniteOnly = bool.Parse(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "spawn_weight")
                                {
                                    temp_plane_type.SpawnWeight = int.Parse(last_child_node.Value.ExpressionValue);
                                }
                            }
                            else if (typeof(PlaneSize) == temp_myth_object_attribute.GetType())
                            {
                                PlaneSize temp_plane_size = (PlaneSize)temp_myth_object_attribute;
                                if (first_child_node.Value.ExpressionValue == "name")
                                {
                                    temp_plane_size.Name = cutStringSigns(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "max_neighbours")
                                {
                                    temp_plane_size.MaxNeighbourPlanes = int.Parse(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "spawn_weight")
                                {
                                    temp_plane_size.SpawnWeight = int.Parse(last_child_node.Value.ExpressionValue);
                                }
                            }
                            else if (typeof(PlaneElement) == temp_myth_object_attribute.GetType())
                            {
                                PlaneElement temp_plane_element = (PlaneElement)temp_myth_object_attribute;
                                if (first_child_node.Value.ExpressionValue == "name")
                                {
                                    temp_plane_element.Name = cutStringSigns(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "opposite")
                                {
                                    temp_plane_element.Opposite = last_child_node.Value.ExpressionValue;
                                }
                                else if (first_child_node.Value.ExpressionValue == "spawn_weight")
                                {
                                    temp_plane_element.SpawnWeight = int.Parse(last_child_node.Value.ExpressionValue);
                                }
                            }
                            else if (typeof(SpeciesTrait) == temp_myth_object_attribute.GetType())
                            {
                                SpeciesTrait temp_trait = (SpeciesTrait)temp_myth_object_attribute;
                                if (first_child_node.Value.ExpressionValue == "name")
                                {
                                    temp_trait.Name = cutStringSigns(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "category")
                                {
                                    temp_trait.Category = cutStringSigns(last_child_node.Value.ExpressionValue);
                                }
                            }
                            else if (typeof(CivilisationEthos) == temp_myth_object_attribute.GetType())
                            {
                                CivilisationEthos temp_ethos = (CivilisationEthos)temp_myth_object_attribute;
                                if (first_child_node.Value.ExpressionValue == "name")
                                {
                                    temp_ethos.Name = cutStringSigns(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "opposite")
                                {
                                    temp_ethos.Opposite = last_child_node.Value.ExpressionValue;
                                }
                            }
                            else if (typeof(SpeciesType) == temp_myth_object_attribute.GetType())
                            {
                                SpeciesType temp_species_type = (SpeciesType)temp_myth_object_attribute;
                                if (first_child_node.Value.ExpressionValue == "name")
                                {
                                    temp_species_type.Name = cutStringSigns(last_child_node.Value.ExpressionValue);
                                }
                                else if (first_child_node.Value.ExpressionValue == "preferred_plane_type")
                                {
                                    temp_species_type.preferredPlaneType = last_child_node.Value.ExpressionValue;
                                }
                                else if (first_child_node.Value.ExpressionValue == "spawn_weight")
                                {
                                    temp_species_type.SpawnWeight = int.Parse(last_child_node.Value.ExpressionValue);
                                }
                            }
                        }
                    }
                }
            }
            else if (current_node.Value.ExpressionType == ExpressionTypes.String)
            {
                if (parent_node.GetFirstChild().Value.ExpressionValue == "domains")
                {
                    data.Domains.Add(cutStringSigns(current_node.Value.ExpressionValue));
                }
                else if (parent_node.GetFirstChild().Value.ExpressionValue == "personalities")
                {
                    data.Personalities.Add(cutStringSigns(current_node.Value.ExpressionValue));
                }
            }
        }



        private string cutStringSigns(string s)
        {
            return s.Substring(1, s.Length - 2);
        }

        private BaseMythObject searchTag(string tag)
        {
            foreach (BaseMythObject mythobj in data.DefinedMythObjects)
            {
                if (mythobj.Tag == tag)
                {
                    return mythobj;
                }
            }

            return null;
        }

        private MythObjectAttribute searchAttributeTag(string tag)
        {
            foreach (MythObjectAttribute mythobj in data.MythObjectAttributes)
            {
                if (mythobj.Tag == tag)
                {
                    return mythobj;
                }
            }

            return null;
        }
    }
}
