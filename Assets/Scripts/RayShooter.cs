﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;



public class RayShooter : MonoBehaviour {
	private Camera _camera;
    private Light _light;
    [SerializeField] GameObject spotLight;
    public float barDisplay;
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(600, 200);
    private Texture2D emptyTex;
    private Texture2D fullTex;
    [SerializeField] GameObject player;
    private FPSInput fps;

    public Texture reticle;

	void Start() {
		_camera = GetComponent<Camera>();
        _light = spotLight.GetComponent<Light>();
        barDisplay = 1;
        fps = player.GetComponent<FPSInput>();
	}

    void OnGUI()
    {
        if (!fps.pauseVisible)
        {
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);


            GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
            GUI.EndGroup();
            GUI.EndGroup();
        }
    }

    void FixedUpdate()
    {
        if (!fps.pauseVisible)
        {
            Ray[] rays = new Ray[10];
            for (int i = 0; i < 9; i++)
            {
                Vector3 point = new Vector3((_camera.pixelWidth / 2) + (i - 4) * 10, _camera.pixelHeight / 2, 0);
                rays[i] = _camera.ScreenPointToRay(point);
                Debug.DrawRay(point, rays[i].direction, Color.red, 20, true);
            }

            if (Input.GetMouseButton(0) && barDisplay > 0.01)
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass1>().PlayMusic();
                barDisplay -= Time.deltaTime * 0.2f;
                if (barDisplay > 0.011)
                {
                    _light.color = new Color(250, 0, 5);


                    foreach (Ray ray in rays)
                    {
                        RaycastHit[] hits = Physics.RaycastAll(ray, 100f);
                        foreach (RaycastHit hit in hits)
                        {
                            GameObject hitObject = hit.transform.gameObject;
                            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                            if (target != null)
                            {
                                target.ReactToHit(this.transform.position, 1);
                            }
                        }
                    }
                }
            }
            else if (Input.GetMouseButton(1) && barDisplay > 0.01)
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass1>().PlayMusic();
                barDisplay -= Time.deltaTime * 0.2f;
                if (barDisplay > 0.011)
                {
                    _light.color = new Color(0, 212, 250);


                    foreach (Ray ray in rays)
                    {
                        RaycastHit[] hits = Physics.RaycastAll(ray, 100f);
                        foreach (RaycastHit hit in hits)
                        {
                            GameObject hitObject = hit.transform.gameObject;
                            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                            if (target != null)
                            {
                                target.ReactToHit(this.transform.position, -1);
                            }
                        }
                    }
                }

            }
            else
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass1>().StopMusic();
                _light.color = new Color(230, 0, 255);
                if (barDisplay < 1)
                {
                    barDisplay += Time.deltaTime * 0.15f;
                }
            }
        }
    }

}