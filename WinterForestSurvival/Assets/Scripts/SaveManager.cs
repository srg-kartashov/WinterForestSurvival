using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class SaveManager : MonoBehaviour
{
    private GameObject _player;
    private GameObject _camera;
    private CharacterStats _characterStats;
    private string path;

    void Awake()
    {
        path = Application.persistentDataPath + "/testsave.xml";
      
    }
    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _camera = GameObject.FindGameObjectWithTag("Camera");
        _characterStats = GetComponent<CharacterStats>();  
        Load();
        Save();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public XElement GetStats()
    {
        XAttribute health = new XAttribute("health", _characterStats.Health);
        XAttribute hunger = new XAttribute("hunger", _characterStats.Hunger);
        //XAttribute thirst = new XAttribute("thirst", _characterStats.Thirst);
        XAttribute cold = new XAttribute("cold", _characterStats.Cold);

        XElement element = new XElement("CharacterStats", health, hunger, cold);
        return element;
    }
    public XElement GetElement(GameObject gameObject, string Name)
    {
        XAttribute x = new XAttribute("x", gameObject.transform.position.x);
        XAttribute y = new XAttribute("y", gameObject.transform.position.y);
        XAttribute z = new XAttribute("z", gameObject.transform.position.z);
        XElement element = new XElement(Name, x, y, z);
        return element;
    }
    public XElement GetTime()
    {
        XAttribute days = new XAttribute("days", GameTime.instance.days);
        XAttribute minutes = new XAttribute("minutes", GameTime.instance.GameMinutes);
        XAttribute hours = new XAttribute("hours", GameTime.instance.GameHours);


        XElement element = new XElement("GameTime", days, minutes, hours);
        return element;
    }
    public XElement GetTemperature()
    {
        XAttribute temperature = new XAttribute("temperature", GameTemperature.instance.Temperature);
        XElement element = new XElement("GameTemperature", temperature);
        return element;
    }
    public XElement GetInventory(Item item)
    {
        XAttribute _item = new XAttribute("item", item.ToString());
        XElement element = new XElement("GameInvenory", _item);
        return element;
    }
    public XElement GetEquipment()
    {
        XAttribute _item = new XAttribute("currentWeapon", EquipmentManager.instance.currentWeapon);
        XElement element = new XElement("EquipmentManager", _item);
        return element;
    }
    public XElement GetCurrentScene()
    {
        XAttribute _scene = new XAttribute("Scene", SceneManager.GetActiveScene().name);
        XElement element = new XElement("CurrentScene", _scene);
        return element;
    }

    public void Save()
    {
        XElement root = new XElement("root");
        root.Add(GetElement(_player, "PlayerPosition"));
        root.Add(GetElement(_camera, "CameraPosition"));
        root.Add(GetStats());
        root.Add(GetTime());
        root.Add(GetTemperature());
        root.Add(GetCurrentScene());
        if (EquipmentManager.instance.currentWeapon != null)
        {
            root.Add(GetEquipment());
        }
        foreach (Item item in Inventory.instance.items)
        {
            root.Add(GetInventory(item));
        }
        XDocument saveDoc = new XDocument(root);
        print(path);
        File.WriteAllText(path, saveDoc.ToString());

    }
    public void Load()
    {
        XElement root = null;
        if (File.Exists(path))
        {

            root = XDocument.Parse(File.ReadAllText(path)).Element("root");

            if (SceneManager.GetActiveScene().name == root.Element("CurrentScene").Attribute("Scene").Value)
            {
                #region координаты_игрока
                Vector3 position = Vector3.zero;
                position.x = float.Parse(root.Element("PlayerPosition").Attribute("x").Value);
                position.y = float.Parse(root.Element("PlayerPosition").Attribute("y").Value);
                position.z = float.Parse(root.Element("PlayerPosition").Attribute("z").Value);
                _player.transform.position = position;
                #endregion координаты_игрока
                #region координаты_камеры
                position = Vector3.zero;
                position.x = float.Parse(root.Element("CameraPosition").Attribute("x").Value);
                position.y = float.Parse(root.Element("CameraPosition").Attribute("y").Value);
                position.z = float.Parse(root.Element("CameraPosition").Attribute("z").Value);
                _camera.transform.position = position;
                #endregion координаты_камеры
            }

            #region характеристики_игрока
            _characterStats.Health = float.Parse(root.Element("CharacterStats").Attribute("health").Value);
            _characterStats.Hunger = float.Parse(root.Element("CharacterStats").Attribute("hunger").Value);
            //_characterStats.Thirst = float.Parse(root.Element("CharacterStats").Attribute("thirst").Value);
            _characterStats.Cold = float.Parse(root.Element("CharacterStats").Attribute("cold").Value);
            #endregion характеристики_игрока
            #region игровое_время
            GameTime.instance.days = int.Parse(root.Element("GameTime").Attribute("days").Value);
            GameTime.instance.GameMinutes = int.Parse(root.Element("GameTime").Attribute("minutes").Value);
            GameTime.instance.GameHours = int.Parse(root.Element("GameTime").Attribute("hours").Value);
            #endregion игровое_время
            #region игровая_температура
            GameTemperature.instance.Temperature = float.Parse(root.Element("GameTemperature").Attribute("temperature").Value);
            #endregion игровая_температура
            #region инвентарь
            Inventory.instance.items.Clear();
            foreach (XElement item in root.Elements("GameInvenory"))
            {
                string _strItem = item.Attribute("item").Value;
                string _path = "Items/" + _strItem.Split()[1].Trim(new Char[] { '(', ')' }) + '/' + _strItem.Split()[0];
                print(_path);
                Inventory.instance.items.Add(Resources.Load(_path) as Item);
            }
            #endregion инвентарь
            #region оружие
            EquipmentManager.instance.UnEquip(true);
            foreach (XElement _currentWeapon in root.Elements("EquipmentManager"))
            {

                string _strItem = _currentWeapon.Attribute("currentWeapon").Value;
                string _pathCurrentWeapon = "Items/" + "Weapon" + '/' + _strItem.Split()[0];
                EquipmentManager.instance.Equip(Resources.Load(_pathCurrentWeapon) as Weapon);

            }





            #endregion оружие




        }

    }
}
