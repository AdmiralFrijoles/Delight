// Internal view logic generated from "TestScene.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TestScene : LayoutRoot
    {
        #region Constructors

        public TestScene(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? TestSceneTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Test1");
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "Test2");
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "Test3");
            Button4 = new Button(this, Group1.Content, "Button4", Button4Template);
            Button4.Click.RegisterHandler(this, "LogBinding");

            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);
            BindingTest1 = new BindingTest(this, Region1.Content, "BindingTest1", BindingTest1Template);

            // binding <BindingTest Player1.Name="{Test}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Test" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "BindingTest1", "Player1", "Name" }, new List<Func<BindableObject>> { () => this, () => BindingTest1, () => BindingTest1.Player1 }), () => BindingTest1.Player1.Name = Test, () => { }, false));
            this.AfterInitializeInternal();
        }

        public TestScene() : this(null)
        {
        }

        static TestScene()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TestSceneTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TestProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(Button4Property);
            dependencyProperties.Add(Button4TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(BindingTest1Property);
            dependencyProperties.Add(BindingTest1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> TestProperty = new DependencyProperty<System.String>("Test");
        public System.String Test
        {
            get { return TestProperty.GetValue(this); }
            set { TestProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> Group1Property = new DependencyProperty<Group>("Group1");
        public Group Group1
        {
            get { return Group1Property.GetValue(this); }
            set { Group1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group1TemplateProperty = new DependencyProperty<Template>("Group1Template");
        public Template Group1Template
        {
            get { return Group1TemplateProperty.GetValue(this); }
            set { Group1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button1Property = new DependencyProperty<Button>("Button1");
        public Button Button1
        {
            get { return Button1Property.GetValue(this); }
            set { Button1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button1TemplateProperty = new DependencyProperty<Template>("Button1Template");
        public Template Button1Template
        {
            get { return Button1TemplateProperty.GetValue(this); }
            set { Button1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button2Property = new DependencyProperty<Button>("Button2");
        public Button Button2
        {
            get { return Button2Property.GetValue(this); }
            set { Button2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button2TemplateProperty = new DependencyProperty<Template>("Button2Template");
        public Template Button2Template
        {
            get { return Button2TemplateProperty.GetValue(this); }
            set { Button2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button3Property = new DependencyProperty<Button>("Button3");
        public Button Button3
        {
            get { return Button3Property.GetValue(this); }
            set { Button3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button3TemplateProperty = new DependencyProperty<Template>("Button3Template");
        public Template Button3Template
        {
            get { return Button3TemplateProperty.GetValue(this); }
            set { Button3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button4Property = new DependencyProperty<Button>("Button4");
        public Button Button4
        {
            get { return Button4Property.GetValue(this); }
            set { Button4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button4TemplateProperty = new DependencyProperty<Template>("Button4Template");
        public Template Button4Template
        {
            get { return Button4TemplateProperty.GetValue(this); }
            set { Button4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region1Property = new DependencyProperty<Region>("Region1");
        public Region Region1
        {
            get { return Region1Property.GetValue(this); }
            set { Region1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region1TemplateProperty = new DependencyProperty<Template>("Region1Template");
        public Template Region1Template
        {
            get { return Region1TemplateProperty.GetValue(this); }
            set { Region1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<BindingTest> BindingTest1Property = new DependencyProperty<BindingTest>("BindingTest1");
        public BindingTest BindingTest1
        {
            get { return BindingTest1Property.GetValue(this); }
            set { BindingTest1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> BindingTest1TemplateProperty = new DependencyProperty<Template>("BindingTest1Template");
        public Template BindingTest1Template
        {
            get { return BindingTest1TemplateProperty.GetValue(this); }
            set { BindingTest1TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class TestSceneTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TestScene;
            }
        }

        private static Template _testScene;
        public static Template TestScene
        {
            get
            {
#if UNITY_EDITOR
                if (_testScene == null || _testScene.CurrentVersion != Template.Version)
#else
                if (_testScene == null)
#endif
                {
                    _testScene = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _testScene.Name = "TestScene";
#endif
                    Delight.TestScene.TestProperty.SetDefault(_testScene, "Example");
                    Delight.TestScene.Group1TemplateProperty.SetDefault(_testScene, TestSceneGroup1);
                    Delight.TestScene.Button1TemplateProperty.SetDefault(_testScene, TestSceneButton1);
                    Delight.TestScene.Button2TemplateProperty.SetDefault(_testScene, TestSceneButton2);
                    Delight.TestScene.Button3TemplateProperty.SetDefault(_testScene, TestSceneButton3);
                    Delight.TestScene.Button4TemplateProperty.SetDefault(_testScene, TestSceneButton4);
                    Delight.TestScene.Region1TemplateProperty.SetDefault(_testScene, TestSceneRegion1);
                    Delight.TestScene.BindingTest1TemplateProperty.SetDefault(_testScene, TestSceneBindingTest1);
                }
                return _testScene;
            }
        }

        private static Template _testSceneGroup1;
        public static Template TestSceneGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneGroup1 == null || _testSceneGroup1.CurrentVersion != Template.Version)
#else
                if (_testSceneGroup1 == null)
#endif
                {
                    _testSceneGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _testSceneGroup1.Name = "TestSceneGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_testSceneGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.AlignmentProperty.SetDefault(_testSceneGroup1, Delight.ElementAlignment.TopLeft);
                    Delight.Group.OffsetProperty.SetDefault(_testSceneGroup1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Group.SpacingProperty.SetDefault(_testSceneGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _testSceneGroup1;
            }
        }

        private static Template _testSceneButton1;
        public static Template TestSceneButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton1 == null || _testSceneButton1.CurrentVersion != Template.Version)
#else
                if (_testSceneButton1 == null)
#endif
                {
                    _testSceneButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testSceneButton1.Name = "TestSceneButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneButton1, TestSceneButton1Label);
                }
                return _testSceneButton1;
            }
        }

        private static Template _testSceneButton1Label;
        public static Template TestSceneButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton1Label == null || _testSceneButton1Label.CurrentVersion != Template.Version)
#else
                if (_testSceneButton1Label == null)
#endif
                {
                    _testSceneButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testSceneButton1Label.Name = "TestSceneButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_testSceneButton1Label, "Test 1");
                }
                return _testSceneButton1Label;
            }
        }

        private static Template _testSceneButton2;
        public static Template TestSceneButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton2 == null || _testSceneButton2.CurrentVersion != Template.Version)
#else
                if (_testSceneButton2 == null)
#endif
                {
                    _testSceneButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testSceneButton2.Name = "TestSceneButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneButton2, TestSceneButton2Label);
                }
                return _testSceneButton2;
            }
        }

        private static Template _testSceneButton2Label;
        public static Template TestSceneButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton2Label == null || _testSceneButton2Label.CurrentVersion != Template.Version)
#else
                if (_testSceneButton2Label == null)
#endif
                {
                    _testSceneButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testSceneButton2Label.Name = "TestSceneButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_testSceneButton2Label, "Test 2");
                }
                return _testSceneButton2Label;
            }
        }

        private static Template _testSceneButton3;
        public static Template TestSceneButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton3 == null || _testSceneButton3.CurrentVersion != Template.Version)
#else
                if (_testSceneButton3 == null)
#endif
                {
                    _testSceneButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testSceneButton3.Name = "TestSceneButton3";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneButton3, TestSceneButton3Label);
                }
                return _testSceneButton3;
            }
        }

        private static Template _testSceneButton3Label;
        public static Template TestSceneButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton3Label == null || _testSceneButton3Label.CurrentVersion != Template.Version)
#else
                if (_testSceneButton3Label == null)
#endif
                {
                    _testSceneButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testSceneButton3Label.Name = "TestSceneButton3Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_testSceneButton3Label, "Test 3");
                }
                return _testSceneButton3Label;
            }
        }

        private static Template _testSceneButton4;
        public static Template TestSceneButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton4 == null || _testSceneButton4.CurrentVersion != Template.Version)
#else
                if (_testSceneButton4 == null)
#endif
                {
                    _testSceneButton4 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testSceneButton4.Name = "TestSceneButton4";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneButton4, TestSceneButton4Label);
                }
                return _testSceneButton4;
            }
        }

        private static Template _testSceneButton4Label;
        public static Template TestSceneButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton4Label == null || _testSceneButton4Label.CurrentVersion != Template.Version)
#else
                if (_testSceneButton4Label == null)
#endif
                {
                    _testSceneButton4Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testSceneButton4Label.Name = "TestSceneButton4Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_testSceneButton4Label, "Log Binding");
                }
                return _testSceneButton4Label;
            }
        }

        private static Template _testSceneRegion1;
        public static Template TestSceneRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneRegion1 == null || _testSceneRegion1.CurrentVersion != Template.Version)
#else
                if (_testSceneRegion1 == null)
#endif
                {
                    _testSceneRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _testSceneRegion1.Name = "TestSceneRegion1";
#endif
                    Delight.Region.MarginProperty.SetDefault(_testSceneRegion1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(200f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _testSceneRegion1;
            }
        }

        private static Template _testSceneBindingTest1;
        public static Template TestSceneBindingTest1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1 == null || _testSceneBindingTest1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1 == null)
#endif
                {
                    _testSceneBindingTest1 = new Template(BindingTestTemplates.BindingTest);
#if UNITY_EDITOR
                    _testSceneBindingTest1.Name = "TestSceneBindingTest1";
#endif
                    Delight.BindingTest.TestBindingProperty.SetDefault(_testSceneBindingTest1, "Patrik");
                    Delight.BindingTest.Region1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Region1);
                    Delight.BindingTest.Group1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Group1);
                    Delight.BindingTest.Button1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button1);
                    Delight.BindingTest.Button2TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button2);
                    Delight.BindingTest.Button3TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button3);
                    Delight.BindingTest.Button4TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button4);
                    Delight.BindingTest.Label1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Label1);
                    Delight.BindingTest.Button5TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button5);
                    Delight.BindingTest.Button6TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button6);
                    Delight.BindingTest.RegionOnDemandTemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1RegionOnDemand);
                    Delight.BindingTest.Group2TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Group2);
                    Delight.BindingTest.Label2TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Label2);
                    Delight.BindingTest.Label3TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Label3);
                }
                return _testSceneBindingTest1;
            }
        }

        private static Template _testSceneBindingTest1Region1;
        public static Template TestSceneBindingTest1Region1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Region1 == null || _testSceneBindingTest1Region1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Region1 == null)
#endif
                {
                    _testSceneBindingTest1Region1 = new Template(BindingTestTemplates.BindingTestRegion1);
#if UNITY_EDITOR
                    _testSceneBindingTest1Region1.Name = "TestSceneBindingTest1Region1";
#endif
                }
                return _testSceneBindingTest1Region1;
            }
        }

        private static Template _testSceneBindingTest1Group1;
        public static Template TestSceneBindingTest1Group1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Group1 == null || _testSceneBindingTest1Group1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Group1 == null)
#endif
                {
                    _testSceneBindingTest1Group1 = new Template(BindingTestTemplates.BindingTestGroup1);
#if UNITY_EDITOR
                    _testSceneBindingTest1Group1.Name = "TestSceneBindingTest1Group1";
#endif
                }
                return _testSceneBindingTest1Group1;
            }
        }

        private static Template _testSceneBindingTest1Button1;
        public static Template TestSceneBindingTest1Button1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button1 == null || _testSceneBindingTest1Button1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button1 == null)
#endif
                {
                    _testSceneBindingTest1Button1 = new Template(BindingTestTemplates.BindingTestButton1);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button1.Name = "TestSceneBindingTest1Button1";
#endif
                    Delight.Button.BackgroundColorProperty.SetDefault(_testSceneBindingTest1Button1, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button1, TestSceneBindingTest1Button1Label);
                }
                return _testSceneBindingTest1Button1;
            }
        }

        private static Template _testSceneBindingTest1Button1Label;
        public static Template TestSceneBindingTest1Button1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button1Label == null || _testSceneBindingTest1Button1Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button1Label == null)
#endif
                {
                    _testSceneBindingTest1Button1Label = new Template(BindingTestTemplates.BindingTestButton1Label);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button1Label.Name = "TestSceneBindingTest1Button1Label";
#endif
                }
                return _testSceneBindingTest1Button1Label;
            }
        }

        private static Template _testSceneBindingTest1Button2;
        public static Template TestSceneBindingTest1Button2
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button2 == null || _testSceneBindingTest1Button2.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button2 == null)
#endif
                {
                    _testSceneBindingTest1Button2 = new Template(BindingTestTemplates.BindingTestButton2);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button2.Name = "TestSceneBindingTest1Button2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button2, TestSceneBindingTest1Button2Label);
                }
                return _testSceneBindingTest1Button2;
            }
        }

        private static Template _testSceneBindingTest1Button2Label;
        public static Template TestSceneBindingTest1Button2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button2Label == null || _testSceneBindingTest1Button2Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button2Label == null)
#endif
                {
                    _testSceneBindingTest1Button2Label = new Template(BindingTestTemplates.BindingTestButton2Label);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button2Label.Name = "TestSceneBindingTest1Button2Label";
#endif
                }
                return _testSceneBindingTest1Button2Label;
            }
        }

        private static Template _testSceneBindingTest1Button3;
        public static Template TestSceneBindingTest1Button3
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button3 == null || _testSceneBindingTest1Button3.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button3 == null)
#endif
                {
                    _testSceneBindingTest1Button3 = new Template(BindingTestTemplates.BindingTestButton3);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button3.Name = "TestSceneBindingTest1Button3";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button3, TestSceneBindingTest1Button3Label);
                }
                return _testSceneBindingTest1Button3;
            }
        }

        private static Template _testSceneBindingTest1Button3Label;
        public static Template TestSceneBindingTest1Button3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button3Label == null || _testSceneBindingTest1Button3Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button3Label == null)
#endif
                {
                    _testSceneBindingTest1Button3Label = new Template(BindingTestTemplates.BindingTestButton3Label);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button3Label.Name = "TestSceneBindingTest1Button3Label";
#endif
                }
                return _testSceneBindingTest1Button3Label;
            }
        }

        private static Template _testSceneBindingTest1Button4;
        public static Template TestSceneBindingTest1Button4
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button4 == null || _testSceneBindingTest1Button4.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button4 == null)
#endif
                {
                    _testSceneBindingTest1Button4 = new Template(BindingTestTemplates.BindingTestButton4);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button4.Name = "TestSceneBindingTest1Button4";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button4, TestSceneBindingTest1Button4Label);
                }
                return _testSceneBindingTest1Button4;
            }
        }

        private static Template _testSceneBindingTest1Button4Label;
        public static Template TestSceneBindingTest1Button4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button4Label == null || _testSceneBindingTest1Button4Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button4Label == null)
#endif
                {
                    _testSceneBindingTest1Button4Label = new Template(BindingTestTemplates.BindingTestButton4Label);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button4Label.Name = "TestSceneBindingTest1Button4Label";
#endif
                }
                return _testSceneBindingTest1Button4Label;
            }
        }

        private static Template _testSceneBindingTest1Label1;
        public static Template TestSceneBindingTest1Label1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Label1 == null || _testSceneBindingTest1Label1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Label1 == null)
#endif
                {
                    _testSceneBindingTest1Label1 = new Template(BindingTestTemplates.BindingTestLabel1);
#if UNITY_EDITOR
                    _testSceneBindingTest1Label1.Name = "TestSceneBindingTest1Label1";
#endif
                }
                return _testSceneBindingTest1Label1;
            }
        }

        private static Template _testSceneBindingTest1Button5;
        public static Template TestSceneBindingTest1Button5
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button5 == null || _testSceneBindingTest1Button5.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button5 == null)
#endif
                {
                    _testSceneBindingTest1Button5 = new Template(BindingTestTemplates.BindingTestButton5);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button5.Name = "TestSceneBindingTest1Button5";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button5, TestSceneBindingTest1Button5Label);
                }
                return _testSceneBindingTest1Button5;
            }
        }

        private static Template _testSceneBindingTest1Button5Label;
        public static Template TestSceneBindingTest1Button5Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button5Label == null || _testSceneBindingTest1Button5Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button5Label == null)
#endif
                {
                    _testSceneBindingTest1Button5Label = new Template(BindingTestTemplates.BindingTestButton5Label);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button5Label.Name = "TestSceneBindingTest1Button5Label";
#endif
                }
                return _testSceneBindingTest1Button5Label;
            }
        }

        private static Template _testSceneBindingTest1Button6;
        public static Template TestSceneBindingTest1Button6
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button6 == null || _testSceneBindingTest1Button6.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button6 == null)
#endif
                {
                    _testSceneBindingTest1Button6 = new Template(BindingTestTemplates.BindingTestButton6);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button6.Name = "TestSceneBindingTest1Button6";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button6, TestSceneBindingTest1Button6Label);
                }
                return _testSceneBindingTest1Button6;
            }
        }

        private static Template _testSceneBindingTest1Button6Label;
        public static Template TestSceneBindingTest1Button6Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button6Label == null || _testSceneBindingTest1Button6Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button6Label == null)
#endif
                {
                    _testSceneBindingTest1Button6Label = new Template(BindingTestTemplates.BindingTestButton6Label);
#if UNITY_EDITOR
                    _testSceneBindingTest1Button6Label.Name = "TestSceneBindingTest1Button6Label";
#endif
                }
                return _testSceneBindingTest1Button6Label;
            }
        }

        private static Template _testSceneBindingTest1RegionOnDemand;
        public static Template TestSceneBindingTest1RegionOnDemand
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1RegionOnDemand == null || _testSceneBindingTest1RegionOnDemand.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1RegionOnDemand == null)
#endif
                {
                    _testSceneBindingTest1RegionOnDemand = new Template(BindingTestTemplates.BindingTestRegionOnDemand);
#if UNITY_EDITOR
                    _testSceneBindingTest1RegionOnDemand.Name = "TestSceneBindingTest1RegionOnDemand";
#endif
                }
                return _testSceneBindingTest1RegionOnDemand;
            }
        }

        private static Template _testSceneBindingTest1Group2;
        public static Template TestSceneBindingTest1Group2
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Group2 == null || _testSceneBindingTest1Group2.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Group2 == null)
#endif
                {
                    _testSceneBindingTest1Group2 = new Template(BindingTestTemplates.BindingTestGroup2);
#if UNITY_EDITOR
                    _testSceneBindingTest1Group2.Name = "TestSceneBindingTest1Group2";
#endif
                }
                return _testSceneBindingTest1Group2;
            }
        }

        private static Template _testSceneBindingTest1Label2;
        public static Template TestSceneBindingTest1Label2
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Label2 == null || _testSceneBindingTest1Label2.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Label2 == null)
#endif
                {
                    _testSceneBindingTest1Label2 = new Template(BindingTestTemplates.BindingTestLabel2);
#if UNITY_EDITOR
                    _testSceneBindingTest1Label2.Name = "TestSceneBindingTest1Label2";
#endif
                }
                return _testSceneBindingTest1Label2;
            }
        }

        private static Template _testSceneBindingTest1Label3;
        public static Template TestSceneBindingTest1Label3
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Label3 == null || _testSceneBindingTest1Label3.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Label3 == null)
#endif
                {
                    _testSceneBindingTest1Label3 = new Template(BindingTestTemplates.BindingTestLabel3);
#if UNITY_EDITOR
                    _testSceneBindingTest1Label3.Name = "TestSceneBindingTest1Label3";
#endif
                }
                return _testSceneBindingTest1Label3;
            }
        }

        #endregion
    }

    #endregion
}
