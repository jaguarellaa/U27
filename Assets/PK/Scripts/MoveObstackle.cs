using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace PK.GameJam
{
    public class MoveObstackle : MonoBehaviour
    {
        [SerializeField] private int obstackleIndex = 0;
        [SerializeField] private float animTime;
        [SerializeField] private Ease ease = Ease.Linear;

        private float startPositionY;
        private Transform animObject;

        private void Awake()
        {
            animObject = transform.GetChild(0);
            startPositionY = animObject.position.y;
        }
        private void OpenAnim(int index)
        {
            if (index == obstackleIndex)
            animObject.DOLocalMoveY(0, animTime).SetEase(ease);
        }
        private void CloseAnim(int index)
        {
            if(index == obstackleIndex)
            {
                animObject.DOLocalMoveY(startPositionY, animTime).SetEase(ease);
            }

        }

        private void OnEnable()
        {
            MoveObstackleOpenSignal.openAnim += OpenAnim;
            MoveObstackleCloseSignal.closeAnim += CloseAnim;
        }
        private void OnDisable()
        {
            MoveObstackleCloseSignal.closeAnim -= CloseAnim;
            MoveObstackleOpenSignal.openAnim -= OpenAnim;
        }

        [ContextMenu("Open")]
        private void Open()
        {
            OpenAnim(0);
        }
    }
}
