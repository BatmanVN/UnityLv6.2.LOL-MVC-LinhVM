using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Joy : BaseCharacter 
{
    [SerializeField] protected VariableJoystick joystick;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speedMove;
    [SerializeField] private float healAmount;
    public bool isUseJoy;

    public float HealAmount { get => healAmount;}
    private void OnValidate() => characterController = GetComponent<CharacterController>();
    private void Start()
    {
        
    }
    private void Update()
    {
        MoveWithJoy();
        MoveWithAgent();
    }
    protected void MoveWithJoy()
    {
        float hInput = joystick.Horizontal;
        float vInput = joystick.Vertical;
        Vector3 direction = new Vector3(hInput, 0, vInput);
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0;

        float moveAnim = characterController.velocity.magnitude;
        characterController.SimpleMove(direction * speedMove);
        if (characterController.velocity != Vector3.zero)
        {
            Quaternion targetRotate = Quaternion.LookRotation(characterController.velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotate,rotateSpeed*Time.deltaTime);
            MoveAnim(ConstString.moveParaname,moveAnim,SmothTime);
            isUseJoy = true;
        }
        if (moveAnim <= 0.1f)
        {
            MoveAnim(ConstString.moveParaname, 0f , SmothTime);
        }
    }
    protected void MoveWithAgent()
    {
        if (isUseJoy)
        {
            Agent.enabled = false;
        }
    }
}
