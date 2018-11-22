using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Основные параметры
    public float speedMove;//скорость персонажа


    //Параметры геймплея для персонажа
    private Vector3 moveVector;
    public PanelsToShow _panelsToShow;
    //Ссылки на компоненты
    public AudioClip deathAudioClip;
    private CharacterController ch_controller;
    private Animator ch_animator;

    private MobileController mController;
    private AudioSource _audioSource;
    public AudioSource eventAudioSoure;

    // Use this for initialization
    private void Start()
    {
        
        _audioSource = gameObject.GetComponent<AudioSource>();
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        mController = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
        _panelsToShow = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<PanelsToShow>();

    }

    // Update is called once per frame
    private void Update()
    {

        CharacterMove();
        //if (Input.GetMouseButtonDown(0))
        //    ch_animator.SetTrigger("Attack");
    }

    public void Attack()
    {
        if (!ch_animator.GetBool("Move"))
        {
            ch_animator.SetTrigger("Attack");
            eventAudioSoure.PlayOneShot(EquipmentManager.instance.currentWeapon.Hit);

        }
    }
    public void Death()
    {
        eventAudioSoure.PlayOneShot(deathAudioClip);
        ch_animator.SetTrigger("Death");
        ch_controller.enabled = false;
        mController.enabled = false;
        _panelsToShow.showDeathMenu();
        this.enabled = false;
        
      
    }

    //метод перемещения персонажа
    private void CharacterMove()
    {
        //перемещение по поверхности
        moveVector = Vector3.zero;
        moveVector.x = mController.Horizontal() * speedMove;
        moveVector.z = mController.Vertical() * speedMove;

        //анимация передвижения персонажа
        if (moveVector.x != 0 || moveVector.z != 0)
        {
            ch_animator.SetBool("Move", true);
            _audioSource.enabled = true;
        }
        else
        {
            ch_animator.SetBool("Move", false);
            _audioSource.enabled = false;
        }

        //поворот персонажа в сторону направления перемещения
        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        ch_controller.Move(moveVector * Time.deltaTime);
    }

}
