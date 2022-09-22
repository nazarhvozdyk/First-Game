using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    protected int numberOfBullets;
    public Transform spawn;
    public Bullet bullet;
    // фото оружия для UI
    public Sprite image;
    public GameObject gunModel;
    public AudioSource shootSound;
    public GameObject flash;
    public ParticleSystem shootEffect;
    public AudioSource emptyGunShoot;

    // уникальный индекс по которому можна найти конкретную пушку
    // используэться чтобы добавить 
    public int gunIndex;
    [Space(5)]
    [Header("Gun parameter")]
    [SerializeField] protected float _bulletSpeed = 10f;
    // количество выстрелов в секунду
    [SerializeField] protected int _shootPeriod = 5;
    [SerializeField] protected int _bulletDamage = 1;

    [Space(5)]
    [Header("Max gun parameter")]

    [SerializeField] protected float _maxBulletSpeed = 30f;
    [SerializeField] protected int _maxShootPeriod = 8;
    [SerializeField] protected int _maxBulletDamage = 3;

    [Space(5)]
    [Header("Gun parameter upgrate price")]
    public int bulletSpeedUpgratePrice = 300;
    public int shootPeriodUpgratePrice = 400;
    public int bulletDamageUpgratePrice = 500;

    // значения, которое мы добавим к текущему значению для улучшения оружия 
    protected int _bulletDamageUpgrateStep = 1;
    protected float _bulletSpeedUpgrateStep = 1f;
    protected int _shootPeriodUpgrateStep = 1;

    [SerializeField] protected bool infinityBullets;
    private float _timer;

    protected virtual void Update()
    {
        _timer += Time.unscaledDeltaTime;

        // находим время для выстрела 1 патрона
        float timeOfSingleShoot = 1f / _shootPeriod;

        if (Input.GetMouseButton(0))
        {
            if (_timer >= timeOfSingleShoot)
            {
                Shoot();
            }
        }
    }
    public virtual void Shoot()
    {
        if (infinityBullets == false && numberOfBullets == 0)
        {
            emptyGunShoot.Play();
            _timer = 0f;

            return;
        }
        if (infinityBullets == false)
        {
            numberOfBullets--;
        }
        _timer = 0f;

        GameObject newBullet = Instantiate(bullet.gameObject, spawn.position, spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = spawn.forward * _bulletSpeed;
        newBullet.GetComponent<Bullet>().damageValue = _bulletDamage;

        shootSound.Play();

        flash.SetActive(true);

        Invoke(nameof(HideFlash), 0.08f);
        shootEffect.Play();
    }

    public void HideFlash()
    {
        flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void DeActivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    { }

    public bool UpgrateBulletSpeed()
    {
        // возвращаєт true если успешно провел апгрейд
        // false если апгрейд зделать невозможно

        if (_bulletSpeed == _maxBulletSpeed)
        {
            return false;
        }
        else
        {
            _bulletSpeed += _bulletSpeedUpgrateStep;
            bulletSpeedUpgratePrice += 100;

            return true;
        }
    }

    public bool UpgrateShootPeriod()
    {
        // возвращаєт true если успешно провел апгрейд
        // false если апгрейд зделать невозможно

        if (_shootPeriod >= _maxShootPeriod)
        {
            return false;
        }
        else
        {
            _shootPeriod += _shootPeriodUpgrateStep;
            shootPeriodUpgratePrice += 100;
            return true;
        }
    }

    public bool UpgrateBulletDamage()
    {
        // возвращаєт true если успешно провел апгрейд
        // false если апгрейд зделать невозможно

        if (_bulletDamage == _maxBulletDamage)
        {
            return false;
        }
        else
        {
            _bulletDamage += _bulletDamageUpgrateStep;
            bulletDamageUpgratePrice += 100;
            return true;
        }
    }

    // эти функции возвращают значение параметра после апгрейта
    // при етом не делают апгрейд пушки
    public float GetUpgrateBulletSpeedValue()
    {
        // если параметер достиг своего максимума
        // функция возвращает максимальное значение 

        if (_bulletSpeed == _maxBulletSpeed)
        {
            return _bulletSpeed;
        }
        else
        {
            return _bulletSpeed + _bulletSpeedUpgrateStep;
        }
    }
    public float GetUpgrateBulletDamageValue()
    {
        if (_bulletDamage == _maxBulletDamage)
        {
            return _bulletDamage;
        }
        else
        {
            return _bulletDamage + _bulletDamageUpgrateStep;
        }
    }
    public float GetUpgrateShootPeriodValue()
    {
        if (_shootPeriod == _maxShootPeriod)
        {
            return _shootPeriod;
        }
        else
        {
            return _shootPeriod + _bulletSpeedUpgrateStep;
        }
    }

    // зделал функции гетеры, потому что применение аксесоров
    // не позволяет присваивать значение в инспекторе 
    public float GetBulletSpeed()
    {
        return _bulletSpeed;
    }
    public float GetShootPeriod()
    {
        return _shootPeriod;
    }
    public int GetBulletDamage()
    {
        return _bulletDamage;
    }
}
