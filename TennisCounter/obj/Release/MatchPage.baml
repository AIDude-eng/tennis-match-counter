   M S B A M L   `   `   `  ����   TennisCounterLibraryY@clr-namespace:TennisCounterLibrary;assembly=TennisCounterLibraryTennisCounterLibrary   TennisCounter   TennisCounter.MatchPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     atenniscounterlibrary@clr-namespace:TennisCounterLibrary;assembly=TennisCounterLibrary       N� Title$  	MatchPage��.��� ���#181735 � RowDefinitions �� �� �� �� �� ��  � ColumnDefinitions �� �� �� �� �� .+��� -   $��Clock��$��4��$��Fonts/#Dosis)�$��Medium"�
�������$��center=�$��center=�$��25(��� -   $��ModeName��$��Fonts/#Dosis)�$��Medium"�
�������$��5��$��center=�$��center=�$��30(��� -   $��	HasServe1��$��Fonts/#Dosis)�$��Heavy"�
�������$��1��$��1��$��center=�$��center=�$��20(�����  �� Path$ Serve1� �� Mode$ OneWay=��� -   $��	HasServe2��$��Fonts/#Dosis)�$��Heavy"�
�������$��1��$��3��$��Center=�$��center=�$��20(����� $ Serve2�$ OneWay=��� -   $��Player1��$��Fonts/#Dosis)�$��Medium"�
�������$��Player 1��$��2��$��1��$��center=�$��center=�$��20(��� -   $��Player2��$��Fonts/#Dosis)�$��Medium"�
�������$��Player 2��$��2��$��3��$��Center=�$��center=�$��20(��� $��2��$��2��$��Fonts/#Dosis)�$��Medium"�
�������$��Center=�$��center=�$��40(�.��:�� -   $��	Add Point��
�������$��Medium"�$��2��$��20(�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ Fonts/#Dosis)���  � �� �#39385D��  �@�Cursor$
 Hand�� �� Triggers P� 	 P� Property	 �@J�IsMouseOver
 P� Value
 . . ���  � �� �#3A3952����  �� 
TargetType" ��.R��� $	��120��$��35�� �� CornerRadius$ 15��#��z��._��� $��Center=�$��Center=��� -   $��	Add Point��
�������$��Medium"�$��2��$��4��$��20(����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#39385D��  �@�Cursor$
 Hand�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#3A3952���� " ��.R��� $	��120��$��35��$ 15��#��z��._��� $��Center=�$��Center=��� -	   $��P1Score��$��Fonts/#Dosis)�$��Medium"�
�������$��3��$��1��$��center=�$��center=�$��20(����� $ Score1�$ OneWay=��� -
   $��P2Score��$��Fonts/#Dosis)�$��Medium"�
�������$��3��$��3��$��center=�$��center=�$��20(����� $ Score2�$ OneWay=��� -   $��ResetButton��$��Reset Scores��
�������$��Medium"�$��5��$��20(����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#FE6584��  �@�Cursor$
 Hand�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#FF4C70���� " ��.R��� $	��130��$��38��$ 15��#��z��._��� $��Center=�$��Center=��� -   $��
MenuButton��$
��Menu��
�������$��Medium"�$��5��$��1��$��20(����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#FE6584��  �@�Cursor$
 Hand�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#FF4C70���� " ��.R��� $	��100��$��38��$ 15��#��z��._��� $��Center=�$��Center=��� -   $��StopClockButton��$��
Stop Clock��
�������$��Medium"�$��5��$��3��$��20(����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#FE6584��  �@�Cursor$
 Hand�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#FF4C70���� " ��.R��� $	��120��$��38��$ 15��#��z��._��� $��Center=�$��Center=��� -   $��ResetClockButton��$��Reset Clock��
�������$��Medium"�$��5��$��5��$��20(����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#FE6584��  �@�Cursor$
 Hand�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#FF4C70���� " ��.R��� $	��120��$��38��$ 15��#��z��._��� $��Center=�$��Center=�