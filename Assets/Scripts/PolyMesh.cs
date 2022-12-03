//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace f�r allgemeine Unity-Assets
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Abstrakte Klasse f�r die Erzeugung eines polygonalen Netzes w�hrend der Laufzeit einer Anwendung
    /// </summary>
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [ExecuteInEditMode]
    public abstract class PolyMesh : MonoBehaviour
    {
        /// <summary>
        /// Kategorie des Shaders, den wir einsetzen.
        /// </summary>
        /// <remarks>
        /// Wir verwenden "Standard" als Default. Falls wir
        /// eine Colormap verwenden bietet es sich an, diesen
        /// Default auf "Unlit/Texture" zu �ndern.
        /// </remarks>
        [Tooltip("Kategorie f�r den verwendeten Shader")]
        public string m_ShaderName = "Standard";

        /// <summary>
        /// Farbe f�r das Netz.
        /// </summary>
        /// <remarks>
        ///Default ist Gelb.
        /// </remarks>
        [Tooltip("Material f�r die Farbe des polygonalen Netzes")]
        public Color netColor = Color.yellow;

        /// <summary>
        /// Wir erzeugen eine Material-Komponente,
        /// so dass wir im Editor dem Netz ein Material zuweisen k�nnen.
        /// </summary>

        [Range(0.05f, 1.5f)]
        [Tooltip("Skalierungsfaktor f�r gleichm�ssige Skalierung")]
        public float ScalingFactor = 1.0f;
        /// <summary>
        /// Wir ben�tigen eine Instanz der Klasse MeshFilter.
        /// </summary>
        protected MeshFilter objectFilter;
        /// <summary>
        /// Mit Hilfe einer Instanz von MeshRenderer stellen wir den platonischen K�rper dar.
        /// </summary>
        protected MeshRenderer objectRenderer;

        /// <summary>
        /// Material erstellen.
        /// </summary>
        /// <remarks>
        /// Wir verwenden die eingestellte Shader-Kategorie und
        /// die Farbe.
        ///
        /// Dabei nutzen wir nicht aus, dass wir pro Dreieck ein eigenes
        /// Material vergeben k�nnen.
        /// </remarks>
        protected Material CreateMaterial()
        {
            var mat = new Material(Shader.Find(m_ShaderName))
            {
                color = netColor
            };
            return mat;
        }
        /// <summary>
        /// Das polygonale Netz wird in der abgeleiteten Klasse
        /// mit Hilfe der Funktion Create erzeugt!
        /// </summary>
        protected abstract void Create();

        /// <summary>
        /// In Awake MeshRenderer und MeshFilter zuordnen und Netz erzeugen.
        /// 
        /// <remarks>
        /// Die Start-Funktion wird hier nicht deklariert und kann in 
        /// abgeleiteten Klassen implementiert werden!
        /// </remarks>
        /// </summary>
        protected virtual void Awake()
        {
            this.objectFilter = gameObject.GetComponent<MeshFilter>();
            this.objectRenderer = gameObject.GetComponent<MeshRenderer>();

            // Polygonales Netz erzeugen
            Create();
        }
    }
}