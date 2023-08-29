using UnityEngine;
using MusicTheory.Rhythms;
using Batterie;

namespace SheetMusic
{
    public class MusicSheet
    {
        public void SelfDestruct()
        {
            Object.Destroy(_parent.gameObject);
        }

        public RhythmSpecs RhythmSpecs;
        public Measure[] Measures;
        public Note[] Notes;
        public MappedBeat[] BeatMap;

        private Transform _parent;
        public Transform Parent => _parent != null ? _parent : _parent = new GameObject(nameof(MusicSheet)).transform;

        private Card _card;
        public Card Card => _card ??= new Card(nameof(Card), Parent)
            .SetCanvasSortingOrder(1);

        //public Card TimeSig;
        //public Card[] ScribedStaves;
        //public Card[] ScribedNotes;
        //public Card[] ScribedCounts;

        private Card _bg;
        public Card BackGround => _bg ??= new Card(nameof(BackGround), Parent)
            .SetImageSprite(Assets.White)
            .SetImageColor(new Color(0, 0, 0, .65f))
            .SetImageSize(new Vector3(Cam.MainOrthoX * 2, Cam.MainOrthoY * 2))
            .SetCanvasSortingOrder(0)
            .SetImagePosition(new Vector3(0, 0, 3));
    }
}